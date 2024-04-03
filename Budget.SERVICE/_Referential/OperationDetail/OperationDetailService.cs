using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.SERVICE._Helpers;
using Budget.SERVICE.GMap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class OperationDetailService : IOperationDetailService
    {
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;
        private readonly IGMapAddressService _gMapAddressService;

        private readonly IOperationDetailRepository _operationDetailRepository;
        private readonly IMapper _mapper;

        public OperationDetailService(
            IBusinessExceptionMessageService businessExceptionMessageService,
            IGMapAddressService gMapAddressService,
            IOperationDetailRepository operationDetailRepository,
            IMapper mapper
            )
        {
            _businessExceptionMessageService = businessExceptionMessageService;
            _gMapAddressService = gMapAddressService;
            _operationDetailRepository = operationDetailRepository;
            _mapper = mapper;
        }

        public OperationDetailDto GetForDetail(int idOperationDetail)
        {
            OperationDetail operationDetail = _operationDetailRepository.GetByIdForDetail(idOperationDetail);

            return _mapper.Map<OperationDetailDto>(operationDetail);
        }

        public OperationDetail GetOrCreate(OperationDetail operationDetail)
        {
            //recherche de l'operation detail
            var operationDetailDuplicate = _operationDetailRepository.GetByOperationDetail(operationDetail);
            if (operationDetailDuplicate != null)
                return operationDetailDuplicate;

            //Recherche si les mots clefs existent déjà pour une autre operation
            if (HasSameKeywords(operationDetail))
            {
                if (operationDetail.KeywordPlace != null)
                {
                    throw new Exception($"La paire de mot clef: {operationDetail.KeywordOperation}/{operationDetail.KeywordPlace} existe déjà pour une autre opération");
                }
                else
                {
                    throw new Exception($"Le mot clef: {operationDetail.KeywordOperation} existe déjà pour une autre opération");
                }
            }

            operationDetail.KeywordOperation = FileHelper.ExcludeForbiddenChars(operationDetail.KeywordOperation.ToUpper());
            operationDetail.KeywordPlace = operationDetail.KeywordPlace!=null ? operationDetail.KeywordPlace.ToUpper() : null;

            if(operationDetail.Id==0)
                return _operationDetailRepository.Create(operationDetail);
            else
            {
                _operationDetailRepository.Update(operationDetail);
                return operationDetail;
            }

        }

        private bool HasSameKeywords(OperationDetail operationDetail)
        {
            return _operationDetailRepository.HasSameKeywords(operationDetail);
        }

        /// <summary>
        /// trouver l'operation à partir du keyword pour les operations non localisables
        /// </summary>
        /// <param name="operationLabel"></param>
        /// <param name="idOperationMethod"></param>
        /// <param name="idMovement"></param>
        /// <returns></returns>
        public OperationDetail GetByKeywordOperation(int idUserGroup, string operationLabel, int idOperationMethod, EnumMovement enumMovement)
        {
            if(operationLabel == "VIRMBRILLOUETNICOLASVIRCHARGESAPPART")
            {
                var tutu= "mm";
            }
            if (operationLabel == "VIRMBRILLOUETNICOLASVIRASSMAT")
            {
                var titi = "mm";
            }
            if (operationLabel== "VIRMBRILLOUETNICOLASVIRCHARGESLOGEMENT")
            {
                var toto = "ok";   
            }
            //retrouver l'operation par le keyword d'operation
            List<OperationDetail> operationDetails = _operationDetailRepository.GetAllByIdOperationMethod(idUserGroup, idOperationMethod);

            operationDetails = operationDetails.Where(x => operationLabel.Contains(x.KeywordOperation)).ToList();
            var lenght = operationDetails.Max(x => x.KeywordOperation);
            operationDetails = operationDetails.Where(x => x.KeywordOperation == lenght).ToList();

            switch (operationDetails.Count)
            {
                case 0:
                    return null;
                case 1:
                    return operationDetails[0];
                default:
                    return null;
                    //throw new Exception("2 keywords identiques présents pour les operations non localisables");
            }

        }

        /// <summary>
        /// trouver l'operation à partir des keywords operation et place pour les operations localisables
        /// </summary>
        /// <param name="operationLabel"></param>
        /// <param name="idOperationMethod"></param>
        /// <param name="idMovement"></param>
        /// <returns></returns>
        public OperationDetail GetByKeywords(int idUserGroup, string operationLabel, int idOperationMethod, EnumMovement enumMovement)
        {
            //retrouver l'operation par le keyword d'operation
            List<OperationDetail> operationDetails = _operationDetailRepository.GetAllByIdOperationMethod(idUserGroup, idOperationMethod);

            operationDetails = operationDetails
                    .Where(x => operationLabel.Contains(x.KeywordOperation))
                    .Where(x => x.KeywordPlace != null
                        && (operationLabel.Contains(x.KeywordPlace)
                        || x.KeywordPlace == "--INTERNET--"
                        || x.KeywordPlace == "-TOREPLACE-"))
                    .ToList();

            switch (operationDetails.Count)
            {
                case 0:
                    return null;
                case 1:
                    return operationDetails[0];
                default:
                    return DetachOperation(operationDetails);
            }
        }

        public OperationDetail FindKeywordPlace(int idUserGroup, string operationLabel)
        {
            return _operationDetailRepository.FindKeywordPlace(idUserGroup, operationLabel);
        }

        public OperationDetail GetUnknown(int idUserGroup)
        {
            var operationDetail = _operationDetailRepository.GetUnknown(idUserGroup);
            return operationDetail;
            //return _mapper.Map<SelectDto>(operationDetail);
        }

        public OperationDetail Save(OperationDetail operationDetail)
        {
            OperationDetail result = operationDetail.Id == 0
                ? _operationDetailRepository.Create(operationDetail)
                : _operationDetailRepository.Update(operationDetail);

            return result;
        }

        public OperationDetail CheckValues(OperationDetailDto operationDetailDto)
        {
            OperationDetail operationDetail;
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();

            if(operationDetailDto ==null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_001));
            }

            operationDetail = operationDetailDto.Id != 0
                ? _operationDetailRepository.GetById(operationDetailDto.Id)
                : _mapper.Map<OperationDetail>(operationDetailDto);
            
            //Check des données
            if (operationDetailDto.Operation == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_002));
            }
            else
            {
                operationDetail.IdOperation = operationDetailDto.Operation.Id;
            }

            
            if (operationDetailDto.OperationPlace == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_004));
            }
            else
            {
                //GMAP ADRESS CHECK
                //operationDetail.IdOperationPlace = operationDetailDto.OperationPlace.Id;
                GMapAddress gMapAddress = _gMapAddressService.CheckValues(operationDetailDto.GMapAddress, (EnumOperationPlace)operationDetail.IdOperationPlace);
                operationDetail.IdGMapAddress = gMapAddress==null ? null : gMapAddress.Id;
            }

            if (operationDetailDto.KeywordOperation == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_003));
            }


            if (operationDetailDto.OperationPlace.Id == (int)EnumOperationPlace.GEO)
            {

                if (operationDetailDto.KeywordPlace == null)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_005));
                }

                if (operationDetailDto.OperationLabel == null)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_006));
                }

                if (operationDetailDto.PlaceLabel == null)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_007));
                }
            }

            //Recherche si les mots clefs existent déjà pour une autre operation
            if (HasSameKeywords(operationDetail))
            {
                if (operationDetailDto.KeywordPlace != null)
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_008));
                    //throw new Exception($"La paire de mot clef: {operationDetail.KeywordOperation}/{operationDetail.KeywordPlace} existe déjà pour une autre opération");
                }
                else
                {
                    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OD_ERR_009));
                    //throw new Exception($"Le mot clef opération existe déjà pour une autre opération");
                }
            }

            operationDetail.KeywordOperation = FileHelper.ExcludeForbiddenChars(operationDetailDto.KeywordOperation.ToUpper());
            operationDetail.KeywordPlace = operationDetailDto.KeywordPlace != null 
                ? FileHelper.ExcludeForbiddenChars(operationDetailDto.KeywordPlace.ToUpper()) : null;
            operationDetail.OperationLabel = !string.IsNullOrEmpty(operationDetailDto.OperationLabel) 
                ? operationDetailDto.OperationLabel.ToUpper() : null;
            operationDetail.PlaceLabel = !string.IsNullOrEmpty(operationDetailDto.PlaceLabel)
                ? operationDetailDto.PlaceLabel.ToUpper() : null;

            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            return operationDetail;
            
        }
        /// <summary>
        /// essai de detacher une operation detail d'une liste en verifiant s'il nexiste pas de doublons
        /// et en ne construisant pas de doublon
        /// </summary>
        /// <param name="operationDetails"></param>
        /// <returns></returns>
        private OperationDetail DetachOperation(List<OperationDetail> operationDetails)
        {
            // selection des operation keyword et operation place grouper
            // si le regroupement ne retourne qu'un seul enregistrement ==> doublon operation keyword et operation place : erreur
            var operations = operationDetails.Select(x => new { operationKeyword = x.KeywordOperation, operationPlace = x.KeywordPlace }).ToList().GroupBy(x => new { x.operationKeyword, x.operationPlace }).ToList();
            if (operations.Count ==1)
            {
                throw new Exception("2 paires de keywords identiques présents pour les operations localisables");
            }
            // sinon prendre le 1er enregistrement trouvé
            else
                return operationDetails[0];

        }

    }

}
