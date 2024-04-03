using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class BusinessExceptionMessageService : IBusinessExceptionMessageService
    {
        private readonly IBusinessExceptionLibraryService _businessExceptionLibraryService;
        public BusinessExceptionMessageService(
            IBusinessExceptionLibraryService businessExceptionLibraryService
            )
        {
            _businessExceptionLibraryService = businessExceptionLibraryService;
        }

        public BusinessExceptionMessage Get(EnumBusinessException enumBusinessException)
        {

            return new BusinessExceptionMessage
            {
                Code = enumBusinessException.ToString(),
                Label = _businessExceptionLibraryService.GetString(enumBusinessException)
            };
        }
    }
}
