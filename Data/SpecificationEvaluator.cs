using System.Linq;
using BabALSaray.AppEntities;
using BabALSaray.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
       public  static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)

       {

          var query = inputQuery;

          if (spec.Criteria != null)
          {
              query = query.Where(spec.Criteria); // p => p.productid == id

          }

          if (spec.OrderBy != null)
          {
              query = query.OrderBy(spec.OrderBy); 
          }

          if (spec.OrderByDescending != null)
          {
              query = query.OrderByDescending(spec.OrderByDescending); 

          }

          if (spec.IspagingEnabled)
          {

             query = query.Skip(spec.Skip).Take(spec.Take);   

          }

          query = spec.Includes.Aggregate(query,(current,include) => current.Include(include));

          return query;

       }
    }
}