using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BabALSaray.AppEntities.Project;

namespace BabALSaray.Specifications
{
    public interface IGenericQuery<T>
    {
      // Lamda expression query.(Orderby or Where or .... ).(Expression<...> expression)
      // So the Expression tree converted to SQL by LINQ Provider
      
      // Func<Project, string> func = p=> p.Name;
      // Expression<Func<Project, object>> func = p=> p.Name
      
      Expression<Func<T, bool>> Criteria {get;} 
      List<Expression<Func<T, object>>> Includes {get;} 

      Expression <Func<T, Object>> OrderBy {get;}
      Expression <Func<T, Object>> OrderByDescending {get;}

      int Take {get;} //to
      int Skip {get;} //from

      bool IspagingEnabled {get;}
    }
}