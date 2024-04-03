using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IBusinessExceptionMessageService
    {
        BusinessExceptionMessage Get(EnumBusinessException enumBusinessException);
    }
}
