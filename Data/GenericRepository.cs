using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.Interfaces;
using BabALSaray.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<int> CountAsync(IGenericQuery<T> spec)
        {
           return await ApplySpecification(spec).CountAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await  _context.Set<T>().ToListAsync();
        }

        

        public async Task<T> GetByIdAsync(int id)
        {
          return await  _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(IGenericQuery<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

       public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(IGenericQuery<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification (IGenericQuery<T> spec)
        
        {
            //Calling from here
           
            return QueryEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);

            // -> SpecificationEvaluater from-> BaseSpecification from-> ISpecification
            
            
        }
    }
}