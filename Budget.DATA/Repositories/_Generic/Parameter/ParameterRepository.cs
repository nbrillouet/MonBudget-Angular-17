using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.DATA.Repositories
{
    public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
    {
        public ParameterRepository(BudgetContext context) : base(context)
        {

        }

        public string GetImportFileDir(int idUser)
        {
            Parameter parameter = Context.Parameter.Where(x => x.IdUser == idUser).FirstOrDefault();
            if (parameter == null)
                return null;
            if (String.IsNullOrEmpty(parameter.ImportFileDir))
                return null;

            return parameter.ImportFileDir;

        }

    }
}
