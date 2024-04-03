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
    public partial class OperationService : IOperationService
    {
        private readonly IMapper _mapper;
        private readonly ISelectService _selectService;
        private readonly IOperationMethodService _operationMethodService;
        private readonly IOperationTypeService _operationTypeService;
        private readonly IAccountStatementCheckReferentialService _accountStatementCheckReferentialService;
        private readonly IBusinessExceptionMessageService _businessExceptionMessageService;
        private readonly IUserService _userService;

        private readonly IOperationRepository _operationRepository;

        public OperationService(
            IMapper mapper,
            ISelectService selectService,
            IOperationMethodService operationMethodService,
            IOperationTypeService operationTypeService,
            IAccountStatementCheckReferentialService accountStatementCheckReferentialService,
            IBusinessExceptionMessageService businessExceptionMessageService,
            IUserService userService,

            IOperationRepository operationRepository
            )
        {
            _mapper = mapper;
            _selectService = selectService;
            _operationMethodService = operationMethodService;
            _operationTypeService = operationTypeService;
            _accountStatementCheckReferentialService = accountStatementCheckReferentialService;
            _userService = userService;
            _businessExceptionMessageService = businessExceptionMessageService;

            _operationRepository = operationRepository;
        }

        public List<Select> GetSelectList(int idUserGroup)
        {
            var operations = _operationRepository.GetSelectList(idUserGroup);
            return _mapper.Map<List<Select>>(operations);
        }


        public List<Select> GetSelectList(int idUserGroup, int idOperationMethod, int idOperationType, EnumSelectType enumSelectType)
        {
            List<Select> selectList = new List<Select>();
            if (enumSelectType == EnumSelectType.Inconnu)
            {
                var select = _mapper.Map<Select>(GetUnknown(idUserGroup));
                selectList.Add(select);
            }
            else
            {
                selectList = _selectService.GetSelectList(enumSelectType);
            }

            //var selectList = _selectService.GetSelectList(EnumTableRef.Operation, idUserGroup,  enumSelectType);
            var operations = _operationRepository.GetSelectList(idUserGroup, idOperationMethod, idOperationType);
            selectList.AddRange(_mapper.Map<IEnumerable<Select>>(operations).ToList());

            return selectList;
        }

        public List<Select> GetSelectList(int idUserGroup, List<Select> operationMethodList, List<Select> operationTypeFamilyList, List<Select> operationTypeList)
        {
            var operations = _operationRepository.GetSelectList(idUserGroup, operationMethodList, operationTypeFamilyList, operationTypeList);
            return _mapper.Map<List<Select>>(operations);
        }
        //public List<SelectDto> GetSelectList(int idUserGroup, List<SelectDto> operationTypes)
        //{
        //    var operations = _operationRepository.GetSelectList(idUserGroup, operationTypes);
        //    return _mapper.Map<List<SelectDto>>(operations);
        //}

        public List<SelectGroupDto> GetSelectGroupListByMovement(int idUserGroup, EnumMovement enumMovement)
        {
            //EnumMovement idMovement = idPoste == (int)EnumMovement.Credit ? EnumMovement.Credit : EnumMovement.Debit;
            List<Operation> operations = _operationRepository.GetByIdMovement(idUserGroup, enumMovement);

            return GetSelectGroupList(operations);
        }

        public List<Select> GetSelectListByIdList(List<int> idList)
        {
            List<Operation> operations = _operationRepository.GetByIdList(idList);
            return _mapper.Map<List<Select>>(operations);
        }

        private List<SelectGroupDto> GetSelectGroupList(List<Operation> operations)
        {
            List<SelectGroupDto> results = new List<SelectGroupDto>();
            //regroupement par idOperationType
            List<OperationType> operationTypes = operations.Select(x => x.OperationType).Distinct().ToList();
            foreach (var operationType in operationTypes)
            {
                SelectGroupDto selectGroup = new SelectGroupDto { Id = operationType.Id, Label = operationType.Label };

                var operationsByOperationType = operations.Where(x => x.IdOperationType == operationType.Id).ToList();
                foreach (var operation in operationsByOperationType)
                {
                    Select selectDto = new Select { Id = operation.Id, Label = operation.Label };
                    selectGroup.Selects.Add(selectDto);
                }

                results.Add(selectGroup);
            }
            return results.OrderBy(x=>x.Label).ToList();
        }

        public Select GetUnknown(int idUserGroup)
        {
            var operation = _operationRepository.GetUnknown(idUserGroup);
            return _mapper.Map<Select>(operation);
        }

        public PagedList<OperationForTableDto> GetForTable(FilterOperationTableSelected filter)
        {
            var pagedList = _operationRepository.GetForTable(filter);

            var result = new PagedList<OperationForTableDto>(_mapper.Map<List<OperationForTableDto>>(pagedList.Datas), pagedList.Pagination);

            foreach(var data in result.Datas)
            {
                Operation operation = _mapper.Map<Operation>(data);
                data.IsUsed = CheckForDelete(operation).Count()>0 ? true : false;
            }

            return result;
        }


        public OperationForDetail GetForDetail(int? idOperation, int idUser)
        {
            var userForGroup = _userService.GetForUserGroup(idUser);
            OperationForDetail operationForDetail = !idOperation.HasValue ? GetForCreate() : GetByIdForDetail(idOperation.Value);
            operationForDetail.User = userForGroup;

            return operationForDetail;
        }

        //public bool HasOt(int idOt)
        //{
        //    return _operationRepository.HasOt(idOt);
        //}


        private OperationForDetail GetForCreate()
        {
            OperationForDetail operationForDetail = new OperationForDetail
            {
                IsMandatory = false,
                OperationMethod = null, // _operationMethodService.GetSelect((int)EnumOperationMethod.Inconnu), 
                OperationType = null //, // _operationTypeService.GetSelect(EnumCodeOperationType.INCO, userForGroupDto.IdUserGroup),
                //User = userForGroupDto
            };

            return operationForDetail;
        }

        private OperationForDetail GetByIdForDetail(int idOperation)
        {
            Operation operation = GetById(idOperation);
            var result = _mapper.Map<OperationForDetail>(operation);
            return result;
        }

        private Operation GetById(int idOperation)
        {
            return _operationRepository.GetForDetail(idOperation);
        }



    }
}
