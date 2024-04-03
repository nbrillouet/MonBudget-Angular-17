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
using System.Text.RegularExpressions;

namespace Budget.SERVICE
{

    public class CreditAgricoleImportFileService : BankingImportService, ICreditAgricoleImportFileService
    {
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;
        private readonly IAccountStatementImportFileService _asifService;
        private readonly IBankFileDefinitionService _bankFileDefinitionService;
        private readonly ReferentialService _referentialService;
        

        public CreditAgricoleImportFileService(
            IMapper mapper,
            IParameterService parameterService,
            IAccountStatementImportFileService asifService,
            IBankFileDefinitionService bankFileDefinitionService,
            ReferentialService referentialService
        )
        {
            _mapper = mapper;
            _parameterService = parameterService;
            _asifService = asifService;
            _bankFileDefinitionService = bankFileDefinitionService;
            _referentialService = referentialService;
        }

        public Boolean isCreditAgricoleFile(string[] header)
        {
            List<BankFileDefinition> bankFileDefinitions = _bankFileDefinitionService.GetByIdBankFamily((int)EnumBankFamily.CreditAgricole);
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

        //Fichier deja formaté pour import (fichier preparé manuellement)
        public bool IsFormatFile(StreamReader reader)
        {
            bool firstLine = true;
            //bool isFormatFile = false;

            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);


            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (firstLine)
                {
                    var header = line.Split(";");
                    if (isCreditAgricoleFile(header))
                        return true;
                    //{
                    //    isFormatFile = true;
                    //    string dir = _parameterService.GetImportFileDir(user.Id);
                    //    dir = dir + "ca_TMP.csv";
                    //    writer = new StreamWriter(dir);
                    //}
                    firstLine = false;
                }
                //if (isFormatFile)
                //{
                //    writer.WriteLine(line);
                //}
                else
                    return false;
            }
            return false;
        }

        public StreamReader GetFormatFile(StreamReader reader, User user)
        {
            bool firstLine = true;
            string dir = _parameterService.GetImportFileDir(user.Id);
            dir = dir + "ca_TMP.csv";

            StreamWriter writer = new StreamWriter(dir);

            while (!reader.EndOfStream)
            {
                if (firstLine)
                    firstLine = false;
                else
                {
                    var line = reader.ReadLine();
                    writer.WriteLine(line);
                }
            }

            writer.Close();
            writer.Dispose();

            StreamReader myReader = new StreamReader(dir);


            return myReader;
        }

        public StreamReader FormatFile(StreamReader reader, User user)
        {
            List<BankFileDefinition> bankFileDefinitions = _referentialService.BankFileDefinitionService.GetByIdBankFamily((int)EnumBankFamily.CreditAgricole);
            
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            string dir = _parameterService.GetImportFileDir(user.Id);
            dir = dir + "ca_TMP.csv";
            StreamWriter writer = new StreamWriter(dir);

            string account = "";
            bool lineFound = false;
            string currentLine = string.Empty;
            //string stream = string.Empty;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(line.Contains("no "))
                {
                    account = line.Substring(line.IndexOf("no ") + 3);
                    account = account.Remove(account.Length-1);
                }

                if ((line.Contains("\"") && !lineFound))
                {
                    line = line.Replace(@"""", string.Empty);
                    currentLine = $"{currentLine}{line.Replace("\r\n","")}";
                    lineFound = true;
                }
                else if (line.Contains("\"") && lineFound)
                {
                    line = line.Replace(@"""", string.Empty);
                    currentLine = $"{currentLine}{line}";
                    string newLine = $"{account};{currentLine}";
                    int countSemiColumn = newLine.Count(f => f == ';');
                    if (countSemiColumn != bankFileDefinitions.Count())
                        newLine = $"{newLine};";

                    writer.WriteLine(newLine);

                    currentLine = string.Empty;
                    lineFound = false;
                }
                else if (lineFound)
                {
                    currentLine = $"{currentLine}{line.Replace("\r\n", "")}";
                }
                var values = line.Split(';');

            }

            writer.Close();
            writer.Dispose();

            StreamReader myReader = new StreamReader(dir);


            return myReader;
        }

        public override List<AccountStatementImportFile> ImportFile(StreamReader reader, AsiForDetail asiForDetail)
        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            List<AsifForDetail> asifForDetailList = new List<AsifForDetail>();
            int currentLineNumber = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                CreditAgricoleFileDto caLine = _mapper.Map<CreditAgricoleFileDto>(line.Split(';'));

                AsifForDetail asifForDetail = new AsifForDetail();
                asifForDetail.Id = currentLineNumber;
                asifForDetail.DateImport = DateTime.Now;
                asifForDetail.Reference = null;
                asifForDetail.LabelAs = caLine.LabelAs.Replace("/t","").Trim();
                asifForDetail.LabelAs = FileHelper.RemoveDiatrics(asifForDetail.LabelAs);
                asifForDetail.LabelAsWork = _asifService.GetOperationLabelWork(asifForDetail.LabelAs);

                if (!string.IsNullOrEmpty(caLine.AmountDebitOperation))
                {
                    asifForDetail.AmountOperation = - double.Parse(caLine.AmountDebitOperation.Replace(",", ".").ToString(), CultureInfo.InvariantCulture);
                    asifForDetail.IdMovement = (int)EnumMovement.Debit;
                }
                else if (!string.IsNullOrEmpty(caLine.AmountCreditOperation))
                {
                    asifForDetail.AmountOperation = double.Parse(caLine.AmountCreditOperation.Replace(",", ".").ToString(), CultureInfo.InvariantCulture);
                    asifForDetail.IdMovement = (int)EnumMovement.Credit;
                }
                asifForDetail.DateIntegration = Convert.ToDateTime(caLine.DateIntegration);

                asifForDetail.Asi = asiForDetail;
                asifForDetail.Account = _referentialService.AccountService.GetForDetailByNumber(caLine.AccountNumber);

                OperationMethod operationMethod = _referentialService.OperationMethodService.GetOperationMethodByFileLabel(asifForDetail.LabelAsWork, EnumBankFamily.CreditAgricole);
                //Date Operation
                if(operationMethod != null)
                {
                    asifForDetail.OperationMethod = _mapper.Map<Select>(operationMethod);
                    switch (operationMethod.Id)
                    {
                        case (int)EnumOperationMethod.PaiementCarte:
                            asifForDetail.DateOperation = GetDateOperationByFileLabel(asifForDetail.LabelAsWork, asifForDetail.DateIntegration.Value, EnumOperationMethod.PaiementCarte);
                            break;
                        case (int)EnumOperationMethod.RetraitCarte:
                            asifForDetail.DateOperation = GetDateOperationByFileLabel(asifForDetail.LabelAsWork, asifForDetail.DateIntegration.Value, EnumOperationMethod.RetraitCarte);
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

                    //asif.IdOperation = operationDetail.Operation.Id;
                    //asif.IdOperationType = operationDetail.Operation.IdOperationType;
                    //asif.IdOperationTypeFamily = operationDetail.Operation.OperationType.IdOperationTypeFamily;
                    //asif.IdOperationDetail = operationDetail.Id;
                    //asif.OperationLabelTemp = operationDetail.Operation.Label;
                    //asif.OperationKeywordTemp = operationDetail.KeywordOperation;
                    //asif.PlaceLabelTemp = operationDetail.KeywordPlace;
                    //asif.PlaceKeywordTemp = operationDetail.KeywordPlace;
                }
                else
                {
                    //Determination de operationDetail (operation+addresse) à partir du label brut
                    //OperationType operationType = _referentialService.OperationTypeService.GetUnknown(user.IdUserGroup);
                    asifForDetail.OperationType = null;// operationType.Id;
                    asifForDetail.OperationTypeFamily = null; // operationType.IdOperationTypeFamily;

                    //rechercher les labels et keyword sur libellé brut
                    OperationInformation operationInformation = GetOperationInformationByParsingLabel(asifForDetail.Asi.User.IdUserGroup, asifForDetail.LabelAs, asifForDetail.LabelAsWork, operationMethod);
                    if (operationInformation != null)
                    {
                        asifForDetail.OdOperationKeyword = operationInformation.OperationKeyword;
                        asifForDetail.OdOperationLabel = operationInformation.OperationLabel;
                        asifForDetail.OdPlaceKeyword = operationInformation.PlaceKeyword;
                        asifForDetail.OdPlaceLabel = operationInformation.PlaceLabel;

                        //asifForDetail.OperationDetail = new OperationDetailDto()
                        //{
                        //    Operation = null,
                        //    KeywordOperation = operationInformation.OperationKeyword,
                        //    KeywordPlace = operationInformation.PlaceKeyword,
                        //    OperationLabel = operationInformation.OperationLabel,
                        //    PlaceLabel = operationInformation.PlaceLabel,
                        //    OperationPlace = null,
                        //    GMapAddress = null
                        //};

                        ////asif.IdOperation = operationInformation.IdOperation;
                        //asif.OperationLabelTemp = operationInformation.OperationLabel;
                        //asif.OperationKeywordTemp = operationInformation.OperationKeyword;
                        //asif.PlaceKeywordTemp = operationInformation.PlaceKeyword;
                        //asif.PlaceLabelTemp = operationInformation.PlaceLabel;

                    }
                }

                asifForDetailList.Add(asifForDetail);

            }
            
            return _mapper.Map<List< AccountStatementImportFile>>( asifForDetailList);
        }

        private DateTime? GetDateOperationByFileLabel(string trimOperationLabel, DateTime dateIntegration, EnumOperationMethod enumOperationMethod)
        {
            int idx = 0;
            int year = dateIntegration.Year;
            string dateOperation=string.Empty;
            switch (enumOperationMethod)
            {
                case EnumOperationMethod.PaiementCarte:
                    //Recherche pos de 'Paiement Par Carte', la date est au format dd/MM et commence 5 pos avant. 
                    //Prendre l'année de la date integration pour mettre annee sur date operation
                    idx = trimOperationLabel.IndexOf("PAIEMENTPARCARTE");
                    if(idx>-1)
                    {
                        idx = idx - 4;
                        dateOperation = trimOperationLabel.Substring(idx, 4);
                    }
                    else if (trimOperationLabel.IndexOf("CARTE")==0)
                    {
                        //date est en dernier dans ce cas si pas presence de "MTINITIAL"
                        var idxInitial = trimOperationLabel.IndexOf("MTINITIAL");
                        if(idxInitial==-1)
                            dateOperation = trimOperationLabel.Substring(trimOperationLabel.Length - 4);
                        else
                        {
                            dateOperation = trimOperationLabel.Substring(idxInitial - 4,4);
                        }
                    }
                    
                    return DateTime.ParseExact($"{dateOperation}{year}", "ddMMyyyy", CultureInfo.CurrentCulture);

                case EnumOperationMethod.RetraitCarte:
                    //Recherche pos de 'Retrait Au Distributeur', la date / heure est au format dd/MM hhhmm et commence 9 pos avant.
                    //Prendre l'année de la date integration pour mettre annee sur date operation
                    idx = trimOperationLabel.IndexOf("RETRAITAUDISTRIBUTEUR");
                    if (idx > -1)
                    {
                        idx = idx - 9;
                        dateOperation = $"{trimOperationLabel.Substring(idx, 4)}{year} {trimOperationLabel.Substring(idx + 4, 5).Replace("H", ":")}:00.000";
                    }
                    else if (trimOperationLabel.IndexOf("RETDAB") == 0)
                    {
                        //date est en dernier dans ce cas si pas presence de "MTINITIAL"
                        var idxInitial = trimOperationLabel.IndexOf("MTINITIAL");
                        if (idxInitial == -1)
                        {
                            var ddmm = trimOperationLabel.Substring(trimOperationLabel.Length - 9).Substring(0, 4);
                            var hh = trimOperationLabel.Substring(trimOperationLabel.Length - 9).Substring(4).Replace("H", ":");
                            dateOperation = $"{ddmm}{year} {hh}:00.000";
                        }
                        else
                        {
                            dateOperation = $"{trimOperationLabel.Substring(idxInitial - 4, 4)}{year} 12:00:00.000";
                        }


                    }

                    return DateTime.ParseExact($"{dateOperation}", "ddMMyyyy HH:mm:ss.fff", CultureInfo.CurrentCulture);
            }

            return null;
        }

        protected override OperationInformation GetOperationInformationByParsingLabel(int idUserGroup, string label, string labelWork, OperationMethod operationMethod)
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
            return null;
        }

        protected override OperationInformation GetOperationInformationForCardPayment(int idUserGroup, string label, string labelWork, string operationMethodKeyword)
        {
            string placeLabel = string.Empty;
            string placeKeyword = string.Empty;
            int idx = 0;
            string operationLabel = string.Empty;

            //recherche position de 'paiement par carte' et enlever la date devant (format ddMM)
            switch (operationMethodKeyword)
            {
                case "PAIEMENTPARCARTE":
                    idx = labelWork.IndexOf(operationMethodKeyword) - 4;
                    operationLabel = labelWork.Substring(0, idx);
                    break;
                case "CARTE":
                    operationLabel = labelWork.Substring(5);
                    break;
            }

            operationLabel = FileHelper.ExcludeNumbers(operationLabel);

            //recherche dans operation_detail le mot clef du lieu
            var operationDetail = _referentialService.OperationDetailService.FindKeywordPlace(idUserGroup, operationLabel);
            if (operationDetail!=null)
            {
                placeLabel = operationDetail.GMapAddress.GMapLocality.Label;
                placeKeyword = operationDetail.KeywordPlace;
                //on enleve tout apres le mot clef de la localisation
                idx = operationLabel.IndexOf(operationDetail.KeywordPlace);
                operationLabel = operationLabel.Substring(0, idx).ToUpper();
            }

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword = operationLabel,// FileHelper.ExcludeForbiddenChars(operationLabel.Replace(" ", "").ToUpper()),
                PlaceLabel = placeLabel,
                PlaceKeyword = placeKeyword
            };

            return operationInformation;
        }
        

        protected override OperationInformation GetOperationInformationForCashWithdrawal(int idUserGroup,string label, string labelWork, string operationMethodKeyword)
        {
            string placeLabel = string.Empty;
            string placeKeyword = string.Empty;
            string operationLabel = string.Empty;

            //recherche dans operation_detail le mot clef du lieu
            var operationDetail = _referentialService.OperationDetailService.FindKeywordPlace(idUserGroup, labelWork);
            if (operationDetail != null)
            {
                placeLabel = operationDetail.GMapAddress.GMapLocality.Label;
                placeKeyword = operationDetail.KeywordPlace;
            }

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = "RETRAIT DAB",
                OperationKeyword = operationMethodKeyword,
                PlaceLabel = placeLabel,
                PlaceKeyword = placeKeyword
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForCotisation(string label, string labelWork, string operationMethodKeyword)
        {
            string operationLabel = string.Empty;

            //rechercher libellé avant mot clef cotisation
            int index = labelWork.IndexOf(operationMethodKeyword);
            operationLabel = labelWork.Substring(0, index); 
            operationLabel = operationLabel.Trim();

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel), 
                OperationKeyword = operationLabel // FileHelper.ExcludeForbiddenChars(operationLabel.Replace(" ", "").ToUpper())
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForVirement(string label, string labelWork, string operationMethodKeyword)
        {
            string operationLabel = string.Empty;

            //rechercher libellé avant mot clef virement en votre faveur
            int index = labelWork.IndexOf(operationMethodKeyword); // accountStatementImportFile.LabelOperation.ToUpper().IndexOf("VIREMENT EN VOTRE FAVEUR");
            operationLabel = labelWork.Substring(0, index); // accountStatementImportFile.LabelOperation.Substring(0,index);
            //label s'arrete au premier chiffre trouvé
            index = FileHelper.IndexFirstNumeric(operationLabel);
            operationLabel = index == -1 ? operationLabel : operationLabel.Substring(0, index);
            //operationLabel = FileHelper.ExcludeNumbers(operationLabel);
            //operationLabel = FileHelper.ExcludeForbiddenChars(operationLabel);
            //operationLabel = operationLabel.ToUpper();
            operationLabel = operationLabel.Trim();

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel), //operationLabel,
                OperationKeyword = operationLabel // FileHelper.ExcludeForbiddenChars(operationLabel.Replace(" ", "").ToUpper())
            };

            return operationInformation;

        }

        protected override OperationInformation GetOperationInformationForRemiseCheque(string label, string labelWork, string operationMethodKeyword)
        {


            //TODO (pas d'exemples)

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = "REMISE CHEQUE"
            };
            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForEmissionCheque(string label, string labelWork, string operationMethodKeyword)
        {

            //TODO (pas d'exemples)

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = "EMISSION CHEQUE"
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForPrelevement(string label, string labelWork, string operationMethodKeyword)
        {
            string operationLabel = string.Empty;

            //rechercher libellé avant mot clef 'Prelevmnt'
            int index = labelWork.IndexOf(operationMethodKeyword); //accountStatementImportFile.LabelOperation.ToUpper().IndexOf("PRELEVMNT");
            operationLabel = labelWork.Substring(0, index); // accountStatementImportFile.LabelOperation.Substring(0,index);
            //operationLabel = operationLabel.ToUpper();
            operationLabel = operationLabel.Trim();

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel), //operationLabel,
                OperationKeyword = operationLabel //FileHelper.ExcludeForbiddenChars(operationLabel.Replace(" ", "").ToUpper())
            };

            return operationInformation;
        }

        protected override OperationInformation GetOperationInformationForFrais(string label, string labelWork, string operationMethodKeyword)
        {
            string operationLabel = string.Empty;

            //TODO (pas d'exemples)

            OperationInformation operationInformation = new OperationInformation
            {
                OperationLabel = FileHelper.GetOperationLabelFromOperationLabelWork(label, operationLabel),
                OperationKeyword = operationLabel // FileHelper.ExcludeForbiddenChars(operationLabel.Replace(" ", "").ToUpper())
            };

            return operationInformation;
        }
    }
}
