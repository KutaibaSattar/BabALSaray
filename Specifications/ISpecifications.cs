using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BabALSaray.Specifications
{
    public interface ISpecifications<T>
    {
      Expression<Func<T, bool>> Criteria {get;} 
      List<Expression<Func<T, object>>> Includes {get;}

      Expression <Func<T, Object>> OrderBy {get;}
      Expression <Func<T, Object>> OrderByDescending {get;}

      int Take {get;} //to
      int Skip {get;} //from

      bool IspagingEnabled {get;}
    }
}