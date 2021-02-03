using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    // All returns better to be IEnumarble not IQuerable , so no need to use again as query 
    //repository get query so no need to repeat them
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;


        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync() ;
        }

        public async Task<TEntity> GetById(int id)
        {
           return await _context.Set<TEntity>().FindAsync(id) ;
        }

         public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await  _context.Set<TEntity>().Where(predicate).ToListAsync() ;
        }

        public void Add(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }





        public void Remove(TEntity entity)
        {
           _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
             _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}