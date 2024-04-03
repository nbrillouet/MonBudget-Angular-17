using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DATA.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        public readonly BudgetContext Context;
        protected BaseRepository(BudgetContext context)
        {
            Context = context;
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public Task<List<T>> GetAllAsync()
        {
            return Context.Set<T>().ToListAsync();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<T> CreateAsync(T entity)
        {
            //Context.Set<T>().Add(entity);
            //Context.SaveChanges();
            await Context.Set<T>().AddAsync(entity);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            return entity;
        }

        public T Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public T CreateWithTran(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return entity;

        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteWithTran(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
