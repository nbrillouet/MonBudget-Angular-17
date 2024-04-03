using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class OperationMethodOtfService : IOperationMethodOtfService
    {
        private readonly IMapper _mapper;
        private readonly IOperationMethodOtfRepository _operationMethodOtfRepository;

        public OperationMethodOtfService(
            IMapper mapper,
            IOperationMethodOtfRepository operationMethodOtfRepository)
        {
            _mapper = mapper;
            _operationMethodOtfRepository = operationMethodOtfRepository;
        }

        public List<SelectCode> GetOtfSelect(int idOperationMethod)
        {
            var otfList = _operationMethodOtfRepository.GetOtfList(idOperationMethod);
            return _mapper.Map<List<SelectCode>>(otfList);
        }
    }

}
