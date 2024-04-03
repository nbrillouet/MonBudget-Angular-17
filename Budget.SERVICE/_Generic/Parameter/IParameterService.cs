using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IParameterService
    {
        string GetImportFileDir(int idUser);
    }
}
