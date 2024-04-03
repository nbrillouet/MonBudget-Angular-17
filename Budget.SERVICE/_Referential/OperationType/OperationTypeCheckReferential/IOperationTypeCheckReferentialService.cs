using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IOperationTypeCheckReferentialService
    {
        bool HasOtf(int idOt);
    }

}
