using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync();
        List<T> GetAll();
        T GetById(int id);
        ValueTask<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        T CreateWithTran(T entity);
        void DeleteWithTran(T entity);
    }
}
