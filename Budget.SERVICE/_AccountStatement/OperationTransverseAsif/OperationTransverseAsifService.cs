using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class OperationTransverseAsifService: IOperationTransverseAsifService
    {
        private readonly IOperationTransverseAsifRepository _operationTransverseAsifRepository;
        private readonly IMapper _mapper;
        private readonly ISelectService _selectService;

        public OperationTransverseAsifService(
            IOperationTransverseAsifRepository operationTransverseAsifRepository,
            IMapper mapper,
            ISelectService selectService

            )
        {
            _mapper = mapper;
            _operationTransverseAsifRepository = operationTransverseAsifRepository;
            _selectService = selectService;
        }

        public List<OperationTransverseAsif> GetByIdAsif(int idAsif)
        {
            return _operationTransverseAsifRepository.GetByIdAsif(idAsif);
        }

        public List<Select> GetOperationTransverseSelectList(int IdAccountStatementFile, EnumSelectType enumSelectType)
        {
            //var selectList = _selectService.GetSelectList(enumSelectType);
            List<Select> selectList = new List<Select>();
            var results = _operationTransverseAsifRepository.GetOperationTransverseList(IdAccountStatementFile);
            selectList.AddRange(_mapper.Map<IEnumerable<Select>>(results).ToList());

            return selectList;
        }

        public bool Update(List<Select> operationTransverses,int idAsif)
        {
            var result = _operationTransverseAsifRepository.Update(operationTransverses, idAsif);
            return result;
        }
    }
}
