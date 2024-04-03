using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class OperationTypeService : IOperationTypeService
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly ISelectService _selectService;
        private readonly IMapper _mapper;
        private readonly IOperationTypeFamilyService _operationTypeFamilyService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;
        private readonly IAccountStatementCheckReferentialService _accountStatementCheckReferentialService;
        private readonly IOperationCheckReferentialService _operationCheckReferentialService;
        private readonly IUserService _userService;

        public OperationTypeService(
            IOperationTypeRepository operationTypeRepository,
            ISelectService selectService,
            IMapper mapper,
            IOperationTypeFamilyService operationTypeFamilyService,
            IBusinessExceptionMessageService businessExceptionMessageService,
            IAccountStatementCheckReferentialService accountStatementCheckReferentialService,
            IOperationCheckReferentialService operationCheckReferentialService,
            IUserService userService
            )
        {
            _operationTypeRepository = operationTypeRepository;
            _selectService = selectService;
            _mapper = mapper;
            _operationTypeFamilyService = operationTypeFamilyService;
            _businessExceptionMessageService = businessExceptionMessageService;
            _accountStatementCheckReferentialService = accountStatementCheckReferentialService;
            _operationCheckReferentialService = operationCheckReferentialService;
            _userService = userService;

        }

        public Select GetSelect(EnumOperationType enumOperationType, int idUserGroup)
        {
            var OperationType = _operationTypeRepository.Get(enumOperationType, idUserGroup);

            return _mapper.Map<Select>(OperationType);
        }

        public OperationType GetByIdWithOperationTypeFamily(int idOperationType)
        {
            return _operationTypeRepository.GetByIdWithOperationTypeFamily(idOperationType);
        }

        public List<SelectGroupDto> GetSelectGroup(int idUserGroup)
        {
            List<SelectGroupDto> results = new List<SelectGroupDto>();
            var operationTypeFamilies = _operationTypeFamilyService.GetByIdUserGroup(idUserGroup);

            return GetSelectGroup(operationTypeFamilies);
            //foreach(var operationTypeFamily in operationTypeFamilies)
            //{
            //    SelectGroupDto selectGroupDto = new SelectGroupDto
            //    {
            //        Id = operationTypeFamily.Id,
            //        Label = operationTypeFamily.Label
            //    };
            //    var operationTypes = _operationTypeRepository.GetByIdOperationTypeFamily(operationTypeFamily.Id);
            //    var operationTypesDto = _mapper.Map<List<SelectDto>>(operationTypes);
            //    selectGroupDto.Selects = operationTypesDto;

            //    results.Add(selectGroupDto);
            //}

            //return results;
        }

        public List<SelectGroupDto> GetSelectGroup(int idUserGroup, List<Select> operationTypeFamilies)
        {
            if(operationTypeFamilies == null || operationTypeFamilies.Count==0)
            {
                operationTypeFamilies = _operationTypeFamilyService.GetByIdUserGroup(idUserGroup);
            }

            return GetSelectGroup(operationTypeFamilies);
            //var operationTypeFamilies = _operationTypeFamilyService.GetByIds(idUserGroup);
        }

        private List<SelectGroupDto> GetSelectGroup(List<Select> operationTypeFamilies)
        {
            List<SelectGroupDto> results = new List<SelectGroupDto>();
            foreach (var operationTypeFamily in operationTypeFamilies)
            {
                SelectGroupDto selectGroupDto = new SelectGroupDto
                {
                    Id = operationTypeFamily.Id,
                    Label = operationTypeFamily.Label
                };
                var operationTypes = _operationTypeRepository.GetByIdOperationTypeFamily(operationTypeFamily.Id);
                var operationTypesDto = _mapper.Map<List<Select>>(operationTypes);
                selectGroupDto.Selects = operationTypesDto;

                results.Add(selectGroupDto);
            }

            return results;
        }

        public List<Select> GetSelectList(int idUserGroup, List<Select> operationTypeFamilies)
        {
            var operationTypes = _operationTypeRepository.GetByOperationTypeFamilies(idUserGroup, operationTypeFamilies);
            return _mapper.Map<List<Select>>(operationTypes);
        }

        public List<Select> GetSelectList(int idAccount, int idMovement, int idOperationTypeFamily, EnumSelectType enumSelectType)
        {
            
            List<Select> selectList = new List<Select>();
            if (enumSelectType == EnumSelectType.Inconnu)
            {
                var operationTypeFamily = _operationTypeFamilyService.GetById(idOperationTypeFamily);
                var select = _mapper.Map<Select>(GetUnknown(operationTypeFamily.IdUserGroup));
                selectList.Add(select);
            }
            else
            {
                selectList = _selectService.GetSelectList(enumSelectType);
            }

            
            var otf = _operationTypeFamilyService.GetById(idOperationTypeFamily);
            var operationTypeList = new List<OperationType>();
            //specifique virement interne
            if (otf!=null && otf.Code==EnumOtf.VIRI.ToString())
                operationTypeList = _operationTypeRepository.GetForViri(idAccount, idMovement, idOperationTypeFamily);
            else
                operationTypeList = _operationTypeRepository.GetByIdOperationTypeFamily(idOperationTypeFamily);

            selectList.AddRange(_mapper.Map<IEnumerable<Select>>(operationTypeList).ToList());

            return selectList;
        }

        public List<SelectGroupDto> GetSelectGroupListByMovement(int idUserGroup, EnumMovement enumMovement)
        {
            //EnumMovement idMovement = idPoste == (int)EnumMovement.Credit ? EnumMovement.Credit : EnumMovement.Debit;
            List<OperationType> operationTypes = _operationTypeRepository.GetByIdMovement(idUserGroup, enumMovement);

            return GetSelectGroupList(operationTypes);
        }
        
        private List<SelectGroupDto> GetSelectGroupList(List<OperationType> operationTypes)
        {
            List<SelectGroupDto> results = new List<SelectGroupDto>();
            //regroupement par idOperationTypeFamily
            List<OperationTypeFamily> operationTypeFamilies = operationTypes.Select(x => x.OperationTypeFamily).Distinct().ToList();
            foreach (var operationTypeFamily in operationTypeFamilies)
            {
                SelectGroupDto selectGroup = new SelectGroupDto { Id = operationTypeFamily.Id, Label = operationTypeFamily.Label };

                var operationTypesByFamily = operationTypes.Where(x => x.IdOperationTypeFamily == operationTypeFamily.Id).ToList();
                foreach (var operationType in operationTypesByFamily)
                {
                    Select selectDto = new Select { Id = operationType.Id, Label = operationType.Label };
                    selectGroup.Selects.Add(selectDto);
                }

                results.Add(selectGroup);
            }
            return results;
        }

        public List<Select> GetSelectListByIdList(List<int> idList)
        {
            List<OperationType> operationTypes = _operationTypeRepository.GetByIdList(idList);
            return _mapper.Map<List<Select>>(operationTypes);
        }

        public OperationType GetUnknown(int idUserGroup)
        {
            var operationType = _operationTypeRepository.GetUnknown(idUserGroup);
            return operationType;
        }

        public PagedList<OtForTableDto> GetForTable(FilterOtTableSelected filter)
        {
            var pagedList = _operationTypeRepository.GetForTable(filter);

            var result = new PagedList<OtForTableDto>(_mapper.Map<List<OtForTableDto>>(pagedList.Datas), pagedList.Pagination);

            foreach (var data in result.Datas)
            {
                OperationType ot = _mapper.Map<OperationType>(data);
                data.IsUsed = CheckForDelete(ot).Count() > 0 ? true : false;
            }

            return result;

        }

        public OtForDetail GetForDetail(int? idOt, int idUser)
        {
            var userForGroup = _userService.GetForUserGroup(idUser);
            OtForDetail otForDetail = !idOt.HasValue ? GetForCreate() : GetByIdForDetail(idOt.Value);
            otForDetail.User = userForGroup;

            return otForDetail;
        }

        public OperationType GetById(int idOt)
        {
            return _operationTypeRepository.GetForDetail(idOt);
        }

        private OtForDetail GetForCreate()
        {
            OtForDetail otForDetail = new OtForDetail
            {
                IsMandatory = false,
                OperationTypeFamily = null //, // _operationMethodService.GetSelect((int)EnumOperationMethod.Inconnu), 
                //User = userForGroupDto
            };

            return otForDetail;
        }

        private OtForDetail GetByIdForDetail(int idOt)
        {
            OperationType ot = GetById(idOt);
            var result = _mapper.Map<OtForDetail>(ot);
            return result;
        }

        

        //public OtForDetail GetForDetail(int idOperationType, int idUserGroup)
        //{
        //    OperationType ot = new OperationType();
        //    if (idOperationType == 0)
        //    {
        //        ot.OperationTypeFamily = new OperationTypeFamily { Id = 1, Label = "INCONNU" };
        //    }
        //    else
        //    {
        //        ot = _operationTypeRepository.GetOtDetail(idOperationType);
        //    }
        //    var otDto = _mapper.Map<OtForDetail>(ot);

        //    otDto.OperationTypeFamily = new ComboSimple<SelectDto>
        //    {
        //        List = _operationTypeFamilyService.GetSelectList(idUserGroup, EnumSelectType.Empty),
        //        Selected = new SelectDto { Id = ot.OperationTypeFamily.Id, Label = ot.OperationTypeFamily.Label }
        //    };

        //    return otDto;
        //}

        public OtForDetail Save(OtForDetail otForDetail)
        {
            OperationType operationType = CheckValues(otForDetail);
            OtForDetail otForDetailSaved = Save(operationType, otForDetail.User.Id);

            return otForDetailSaved;
        }

        private OperationType CheckValues(OtForDetail otForDetail)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Check des données      
            //IsExist(couvertureForData, forcableSave, businessExceptionMessages);
            //if (HelperDate.IsWeekEnd(couvertureForData.DateOperation))
            //{
            //    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_ERR_046, true));
            //}


            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            return _mapper.Map<OperationType>(otForDetail);
        }

        private OtForDetail Save(OperationType operationType, int idUser)
        {
            operationType = operationType.Id == 0
               ? Create(operationType)
               : Update(operationType);

            OtForDetail otForDetail = GetForDetail(operationType.Id, idUser);

            return otForDetail;
        }

        private OperationType Create(OperationType operationType)
        {
            operationType = _operationTypeRepository.Create(operationType);
            return operationType;
        }

        private OperationType Update(OperationType operationType)
        {
            operationType = _operationTypeRepository.Update(operationType);
            return operationType;
        }

        //public void DeleteOtList(List<int> idOtList, int idUserGroup)
        //{
        //    CheckForDeleteOperationTypeList(idOtList);
        //    foreach (var idOperation in idOtList)
        //    {
        //        Delete(idOperation);
        //    }
        //}

        public void Delete(List<int> listIdOt)
        {
            CheckForDeleteList(listIdOt);
            foreach (var idOt in listIdOt)
            {
                OperationType ot = GetById(idOt);
                if (ot != null)
                {
                    Delete(ot);
                }
            }
        }

        private void Delete(OperationType ot)
        {
            _operationTypeRepository.Delete(ot);
        }

        //private bool Delete(int idOt)
        //{
        //    var ot = _operationTypeRepository.GetById(idOt);

        //    _operationTypeRepository.Delete(ot);

        //    return true;
        //}

        private void CheckForDeleteList(List<int> idOtList)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            foreach (var idOt in idOtList)
            {
                var ot = _operationTypeRepository.GetById(idOt);
                businessExceptionMessages.AddRange(CheckForDelete(ot));
            }

            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private List<BusinessExceptionMessage> CheckForDelete(OperationType ot)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Recherche si operation est mandatory
            if (ot.IsMandatory)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OTY_ERR_000));

            //Recherche si operation type utilisée dans account statement file
            if (_accountStatementCheckReferentialService.AsifHasOt(ot.Id))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OTY_ERR_001));
            }

            //Recherche si operation type utilisé dans account statement
            if (_accountStatementCheckReferentialService.AsHasOt(ot.Id))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OTY_ERR_002));
            }

            //Recherche si operation type utilisé dans operation
            if(_operationCheckReferentialService.HasOt(ot.Id))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OTY_ERR_003));
            }

            return businessExceptionMessages;
            //if (businessExceptionMessages.Count > 0)
            //{
            //    throw new BusinessException(businessExceptionMessages);
            //}
        }


    }
}
