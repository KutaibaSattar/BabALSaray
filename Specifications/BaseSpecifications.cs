using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BabALSaray.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T>

    {
        public BaseSpecifications()
        {

        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} =
            new List<Expression<Func<T,Object>>>();

        public Expression<Func<T, object>> OrderBy  {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IspagingEnabled {get; private set;}

        protected void AddInclude(Expression<Func<T,Object>> IncludeExression)
        {
           Includes.Add(IncludeExression);
        }

        protected void AddOrderBy (Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;

        }
        protected void AddOrderByDescending (Expression<Func<T,object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;

        }

        protected void ApplyPaging(int skip , int take)
        {
                Skip = skip;
                Take = take;
                IspagingEnabled = true;
        }


    }
}