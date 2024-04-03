using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Budget.SERVICE
{
    public class BusinessExceptionLibraryService : IBusinessExceptionLibraryService
    {
        public BusinessExceptionLibraryService(
            )
        {

        }

        public string GetString(EnumBusinessException enumBusinessException)
        {
            ResourceManager resourceManager = new ResourceManager("Budget.SERVICE.BusinessExceptionLibrary", Assembly.GetExecutingAssembly());

            return resourceManager.GetString(enumBusinessException.ToString(), CultureInfo.CurrentCulture);
        }

    }
}
