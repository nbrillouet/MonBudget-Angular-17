using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IBusinessExceptionLibraryService
    {
        string GetString(EnumBusinessException enumBusinessException);
    }
}
