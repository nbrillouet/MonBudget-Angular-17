using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IAccountStatementCheckReferentialService
    {
        bool AsifHasOperation(int idOperation);
        bool AsHasOperation(int idOperation);

        bool AsifHasOt(int idOt);
        bool AsHasOt(int idOt);

        bool AsifHasOtf(int idOtf);
        bool AsHasOtf(int idOtf);

        bool AsHasAsi(int idAsi);
    }
}
