using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.ContextTransaction
{
    public class ContextTransaction : IContextTransaction
    {
        private DbContext _dbContext;

        public ContextTransaction(BudgetContext context)
        {
            _dbContext = context;
        }

        public int Commit()
        {
            // Save changes with the default options
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

    }
}
