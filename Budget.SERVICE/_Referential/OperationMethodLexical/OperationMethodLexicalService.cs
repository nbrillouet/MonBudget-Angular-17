using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class OperationMethodLexicalService : IOperationMethodLexicalService
    {
        private readonly IOperationMethodLexicalRepository _operationMethodLexicalRepository;
        public OperationMethodLexicalService(IOperationMethodLexicalRepository operationMethodLexicalRepository)
        {
            _operationMethodLexicalRepository = operationMethodLexicalRepository;
        }

        public List<OperationMethodLexical> GetAllByOrder()
        {
            return _operationMethodLexicalRepository.GetAllByOrder();
        }
    }
}
