using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IUserCheckReferentialService
    {
        bool HasOtf(int idOtf);
    }
}
