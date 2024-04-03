using Budget.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class OperationTypeCheckReferentialService : IOperationTypeCheckReferentialService
    {
        //private readonly IMapper _mapper;
        private readonly IOperationTypeRepository _operationTypeRepository;


        public OperationTypeCheckReferentialService(
            IOperationTypeRepository operationTypeRepository
            )
        {
            //_mapper = mapper;
            _operationTypeRepository = operationTypeRepository;
        }

        public bool HasOtf(int idOtf)
        {
            return _operationTypeRepository.HasOtf(idOtf);
        }

        
    }

}
