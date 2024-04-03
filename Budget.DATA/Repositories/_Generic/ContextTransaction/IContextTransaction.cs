using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.DATA.Repositories.ContextTransaction
{
    public interface IContextTransaction : IDisposable
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
