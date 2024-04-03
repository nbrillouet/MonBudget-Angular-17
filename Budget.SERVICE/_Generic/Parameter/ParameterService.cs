using Budget.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _parameterRepository;
        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public string GetImportFileDir(int idUser)
        {
            return _parameterRepository.GetImportFileDir(idUser);
        }
    }
}
