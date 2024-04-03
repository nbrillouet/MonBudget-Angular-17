using Budget.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class OperationCheckReferentialService : IOperationCheckReferentialService
    {
        //private readonly IMapper _mapper;
        private readonly IOperationRepository _operationRepository;


        public OperationCheckReferentialService(
            IOperationRepository operationRepository
            )
        {
            //_mapper = mapper;
            _operationRepository = operationRepository;
        }

        public bool HasOt(int idOt)
        {
            return _operationRepository.HasOt(idOt);
        }

        
    }

}
