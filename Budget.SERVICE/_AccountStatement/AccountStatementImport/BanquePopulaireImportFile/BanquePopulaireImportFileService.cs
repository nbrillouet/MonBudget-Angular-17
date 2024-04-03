using AutoMapper;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.SERVICE._Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class BanquePopulaireImportFileService : BankingImportService, IBanquePopulaireImportFileService
    {
        private readonly IMapper _mapper;
        private readonly IAccountStatementImportFileService _asifService;
        private readonly IBankFileDefinitionService _bankFileDefinitionService;
        private readonly ReferentialService _referentialService;

        public BanquePopulaireImportFileService(
            IMapper mapper,
            IAccountStatementImportFileService asifService,
            IBankFileDefinitionService bankFileDefinitionService,
            ReferentialService referentialService
            )
        {
            _asifService = asifService;
            _bankFileDefinitionService = bankFileDefinitionService;
            _referentialService = referentialService;
            _mapper = mapper;
        }

        public Boolean isBanquePopulaireFile(string[] header)
        {
            List<BankFileDefinition> bankFileDefinitions = _bankFileDefinitionService.GetByIdBankFamily((int)EnumBankFamily.BanquePopulaire);
            if (header.Length == bankFileDefinitions.Count)
            {
                for (int i = 0; i < bankFileDefinitions.Count; i++)
                {
                    if (header[i] != bankFileDefinitions[i].LabelField)
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public override List<AccountStatementImportFile> ImportFile(StreamReader reader, AsiForDetail asiForDetail)
        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            List<AsifForDetail> asifForDetailList = new List<AsifForDetail>();

            try
            {
                int currentLineNumber = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (currentLineNumber != 0)
                    {
                        BanquePopulaireFileDto bpLine = _mapper.Map<BanquePopulaireFileDto>(line.Split(';'));

                        AsifForDetail asifForDetail = new AsifForDetail();
                        asifForDetail.Id = currentLineNumber;
                        asifForDetail.DateImport = DateTime.Now;
                        asifForDetail.Reference = bpLine.Reference.Trim();
                        asifForDetail.LabelAs = bpLine.LabelAs;
                        asifForDetail.LabelAsCopy = GetLabelAsCopy(asifForDetail.LabelAs);
                        asifForDetail.LabelAsWork = _asifService.GetOperationLabelWork(asifForDetail.LabelAsCopy);
                        asifForDetail.AmountOperation = double.Parse(bpLine.AmountOperation.Replace(",", ".").ToString(), CultureInfo.InvariantCulture);
                        asifForDetail.DateIntegration = DateTime.ParseExact(bpLine.DateIntegration, "dd/MM/yyyy", CultureInfo.CurrentCulture); //Convert.ToDateTime(values[1].ToString());
                        asifForDetail.IdMovement = asifForDetail.AmountOperation > 0 ? 1 : 2;

                        asifForDetail.Asi = asiForDetail;
                        asifForDetail.Account = _referentialService.AccountService.GetForDetailByNumber(bpLine.AccountNumber);

                        OperationMethod operationMethod = _referentialService.OperationMethodService.GetOperationMethodByFileLabel(asifForDetail.LabelAsWork, EnumBankFamily.BanquePopulaire);
                        if (operationMethod != null)
                        {
                            asifForDetail.OperationMethod = _mapper.Map<Select>(operationMethod);
                            //Date Operation
                            switch (asifForDetail.OperationMethod.Id)
                            {
                                case (int)EnumOperationMethod.PaiementCarte:
                                    asifForDetail.DateOperation = GetDateOperationByFileLabel(asifForDetail.LabelAsWork, EnumOperationMethod.PaiementCarte);
                                    break;
                                case (int)EnumOperationMethod.RetraitCarte:
                                    asifForDetail.DateOperation = GetDateOperationByFileLabel(asifForDetail.LabelAsWork, EnumOperationMethod.RetraitCarte);
                                    break;
                            }
                        }

                        //Determination de operationDetail (operation+addresse) à partir des keywords
                        OperationDetail operationDetail = _asifService.GetOperationDetail(asifForDetail);
                        if (operationDetail != null)
                        {
                            asifForDetail.Operation = _mapper.Map<Select>(operationDetail.Operation);
                            asifForDetail.OperationType = _mapper.Map<Select>(operationDetail.Operation.OperationType);
                            asifForDetail.OperationTypeFamily = _mapper.Map<SelectCode>(operationDetail.Operation.OperationType.OperationTypeFamily);
                            asifForDetail.OperationDetail = _mapper.Map<OperationDetailDto>(operationDetail);

                            //cas virement interne apres rechercher auto
                            //TODO A recontroler a lenregistrement vers account statement (a factoriser egalement .ce mecanisme est utilisé ailleurs)
                            if (operationDetail.Operation.OperationType.OperationTypeFamily.Code == EnumOtf.VIRI.ToString())
                            {
                                //asifForDetail.Account.Id
                                var accountNumber = asifForDetail.OperationType.Label.Split('-')[3].Trim();
                                var a = _referentialService.AccountService.GetByNumber(accountNumber);
                                //si le compte = compte depuis ou vers--> compte de operation type erroné--> suppression
                                if(a.Id== asifForDetail.Account.Id)
                                {
                                    asifForDetail.OperationType = null;
                                    asifForDetail.Operation = null;
                                }
                            }

                        }
                        else
                        {
                            //Determination de operationDetail (operation+addresse) à partir du label brut
                            asifForDetail.OperationType = null;
                            asifForDetail.OperationTypeFamily = null;

                            //rechercher les labels et keyword sur libellé brut
                            OperationInformation operationInformation = GetOperationInformationByParsingLabel(asifForDetail.Asi.User.IdUserGroup, asifForDetail.LabelAsCopy, asifForDetail.LabelAsWork, operationMethod);
                            if (operationInformation != null)
                            {
                                asifForDetail.OdOperationKeyword = operationInformation.OperationKeyword;
                                asifForDetail.OdOperationLabel = operationInformation.OperationLabel;
                                asifForDetail.OdPlaceKeyword = operationInformation.PlaceKeyword;
                                asifForDetail.OdPlaceLabel = operationInformation.PlaceLabel;
                            }
                        }

                        asifForDetailList.Add(asifForDetail);

                    }
                    currentLineNumber++;
                }
            }
            catch(Exception ex)
            {
                var t = "ko";
            }
            

            return _mapper.Map<List<AccountStatementImportFile>>(asifForDetailList);

        }

        private string GetLabelAsCopy(string label)
        {
            string labelAs = label.ToUpper();
            //PATCH: Nouveau format fichier BPVF, on applique le changement sur l'ancien format
            //si "CARTE" est premier mot rencontré --> on le remplace par "" et on met CB**** apres la date
            if (labelAs.IndexOf("CARTE")==0)
            {
                labelAs = labelAs.Substring(6);
                labelAs = labelAs.Trim();
                //On recherche la date
                string date = labelAs.Substring(0, 6);
                //on remplace "CB*" par "CB****" ou "SC*" par "CB****"
                labelAs = labelAs.Replace("CB*", "CB****");
                labelAs = labelAs.Replace("SC*", "CB****");
            }

            return labelAs;
        }

        private DateTime? GetDateOperationByFileLabel(string operationLabelWork, EnumOperationMethod enumOperationMethod)
        {
            string dateOperation;
            int index = -1;
            switch (enumOperationMethod)
            {
                case EnumOperationMethod.PaiementCarte:
                    //////commence apres 'CARTE' prendre les 6 caractères suivants (date de longueur 6 au format ddMMyy)
                    ////index = operationLabelWork.IndexOf("CARTE") + "CARTE".Length;
                    ////dateOperation = operationLabelWork.Substring(index, 6);
                    //Date est situé sur les 6 premiers caractères
                    dateOperation = operationLabelWork.Substring(0, 6);
                    return DateTime.ParseExact(dateOperation, "ddMMyy", CultureInfo.CurrentCulture);

                case EnumOperationMethod.RetraitCarte:
                    //commence apres RETRAITDU, prendre les 6 caracteres suivants (date de longueur 6 au format ddMMyy)
                    index = operationLabelWork.IndexOf("RETRAITDU");
                    if (index > -1)
                    {
                        index = index + "RETRAITDU".Length;
                        dateOperation = operationLabelWork.Substring(index, 6);
                        return DateTime.ParseExact(dateOperation, "ddMMyy", CultureInfo.CurrentCulture);
                    }
                    return null;

            }

            return null; ;
        }

        protected override OperationInformation GetOperationInformationByParsingLabel(int idUserGroup, string label,string labelWork, OperationMethod operationMethod)
        {
            if(operationMethod!=null)
            {
                switch (operationMethod.Id)
                {
                    case (int)EnumOperationMethod.PaiementCarte:
                        return GetOperationInformationForCardPayment(idUserGroup, label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.RetraitCarte:
                        return GetOperationInformationForCashWithdrawal(idUserGroup, label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.Cotisation:
                        return GetOperationInformationForCotisation(label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.Virement:
                        return GetOperationInformationForVirement(label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.RemiseCheque:
                        return GetOperationInformationForRemiseCheque(label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.EmissionCheque:
                        return GetOperationInformationForEmissionCheque(label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.Prelevement:
                        return GetOperationInformationForPrelevement(label, labelWork, operationMethod.KeywordWork);
                    case (int)EnumOperationMethod.Frais:
                        return GetOperationInformationForFrais(label, labelWork, operationMethod.KeywordWork);
                }
            }
            
            return null;
        }

        protected override OperationInformation GetOperationInformationForCardPayment(int idUserGroup, string label, string labelWork, string operationMethodKeyword)
        {
            string operationLabel = string.Empty;
            string operationPlace = string.Empty;

            string fileLabelTmp = labelWork;
            //Rechercher mot clef 'DONT FRAIS' et si present Enlever tout apres 'DONT FRAIS'
            int pos = fileLabelTmp.IndexOf("DONTFRAIS");
            if (pos != -1)
            {
                fileLabelTmp = fileLabelTmp.Substring(0, pos);
                fileLabelTmp = fileLabelTmp.Trim();
            }

            //Recherche du debut du label par le mot cle: CB****
            pos = fileLabelTmp.IndexOf("CB****");

            fileLabelTmp = fileLabelTmp.Substring(pos + "CB****".Length);

            //retrait des chiffres situé apres CB ou SC
            for (int i = 0; i < fileLabelTmp.Length; i++)
            {
                char c = Convert.ToChar(fileLabelTmp.Substring(i, 1));
                if (!Char.IsNumber(c))
                {
                    fileLabelTmp = fileLabelTmp.Substring(i);
                    break;
                }
            }

            //Arret du label dès le 1er chiffre
            int indexPlace = -1;
            for (int i = 0; i < fileLabelTmp.Length; i++)
            {
                char c = Convert.ToChar(fileLabelTmp.Substring(i, 1));
                if (Char.IsNumber(c))
                {
                    operationLabel = fileLabelTmp.Substring(0, i);
                    indexPlace = i;
                    break;
                }
            }

            if (indexPlace == -1)
            {
                operationLabel = fileLabelTmp;
            }
            else
            {
                //determination du lieu à partir de l'indexPlace
                operationPlace = fileLabelTmp.Substring(indexPlace);
                //suppression des chiffres si > 2
                var countNumber = operationPlace.Count(Char.IsDigit);
                operationPlace = countNumber > 2 ? FileHelper.ExcludeNumbers(operationPlace) : operationPlace;
            }

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword = operationLabel, //FileHelper.ExcludeForbiddenChars(operationLabel.Replace(" ", "").ToUpper()),
                PlaceLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label,operationPlace),
                PlaceKeyword = FileHelper.ExcludeNumbers(operationPlace)
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForCashWithdrawal(int idUser, string label, string labelWork, string operationMethodKeyword)
        {
            //  Le lieu est du debut jusqu'au mot clef
            //  lieu est a mettre dans place
            var index = labelWork.IndexOf(operationMethodKeyword);
            var operationPlace = labelWork.Substring(0, index);

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = "RETRAIT DAB",
                OperationKeyword = operationMethodKeyword,
                PlaceLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationPlace),
                PlaceKeyword = FileHelper.ExcludeNumbers(operationPlace)
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForCotisation(string label, string labelWork, string operationMethodKeyword)
        {
            //rechercher libellé apres mot clef cotisation
            var index = labelWork.IndexOf(operationMethodKeyword) + operationMethodKeyword.Length;
            string operationLabel = labelWork.Substring(index);

            //Arret du label dès le 1er chiffre
            int indexPlace = -1;
            for (int i = 0; i < operationLabel.Length; i++)
            {
                char c = Convert.ToChar(operationLabel.Substring(i, 1));
                if (Char.IsNumber(c))
                {
                    operationLabel = operationLabel.Substring(0, i);
                    indexPlace = i;
                    break;
                }
            }

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword = operationLabel
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForVirement(string label, string labelWork, string operationMethodKeyword)
        {
            //rechercher libellé apres mot clef virement
            var index = labelWork.IndexOf(operationMethodKeyword);
            string operationLabel = labelWork.Substring(index + operationMethodKeyword.Length);

            //fin du label est au 1er chiffre trouvé
            for (int i = 0; i < operationLabel.Length; i++)
            {
                char c = Convert.ToChar(operationLabel.Substring(i, 1));
                if (Char.IsNumber(c))
                {
                    operationLabel = operationLabel.Substring(0, i);
                    break;
                }
            }

            OperationInformation operationInformation = new OperationInformation
            {

                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword  = $"{operationMethodKeyword}{operationLabel}"
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForRemiseCheque(string label, string labelWork, string operationMethodKeyword)
        {
            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = "REMISE CHEQUE",
                OperationKeyword = operationMethodKeyword
            };
            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForEmissionCheque(string label, string labelWork, string operationMethodKeyword)
        {
            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = "EMISSION CHEQUE",
                OperationKeyword = operationMethodKeyword
            };
            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForPrelevement(string label, string labelWork, string operationMethodKeyword)
        {
            //rechercher libellé apres mot clef prelevement
            var index = labelWork.IndexOf(operationMethodKeyword);
            string operationLabel = labelWork.Substring(index + operationMethodKeyword.Length);

            //fin du label est au 1er chiffre trouvé
            for (int i = 0; i < operationLabel.Length; i++)
            {
                char c = Convert.ToChar(operationLabel.Substring(i, 1));
                if (Char.IsNumber(c))
                {
                    operationLabel = operationLabel.Substring(0, i);
                    break;
                }
            }

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword = $"{operationMethodKeyword}{operationLabel}"
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForFrais(string label, string labelWork, string operationMethodKeyword)
        {
            //rechercher libellé apres mot clef frais
            int index = labelWork.IndexOf(operationMethodKeyword) + operationMethodKeyword.Length;
            string operationLabel = labelWork.Substring(index);
            operationLabel = operationLabel.Trim();

            //Arret du label dès le 1er chiffre
            int indexPlace = -1;
            for (int i = 0; i < operationLabel.Length; i++)
            {
                char c = Convert.ToChar(operationLabel.Substring(i, 1));
                if (Char.IsNumber(c))
                {
                    operationLabel = operationLabel.Substring(0, i);
                    indexPlace = i;
                    break;
                }
            }

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword = $"{operationMethodKeyword}{operationLabel}"
            };

            return operationInformation;
        }
    }

}
