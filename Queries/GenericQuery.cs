using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BabALSaray.Specifications
{
    public class GenericQuery<T> : IGenericQuery<T>

    {
        
        
        /* public BaseSpecifications()
        {

        } */

        //1---------------------------------
        public Expression<Func<T, bool>> Criteria {get;}
        public GenericQuery(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }
        //---------------------------------1
       
        //2-----------------------------------
        public List<Expression<Func<T, object>>> Includes {get;} =
            new List<Expression<Func<T,Object>>>(); // making a new List

        protected void AddInclude(Expression<Func<T,Object>> IncludeExression)
        {
           Includes.Add(IncludeExression); // Push to list
        }
        //-------------------------------------2

      
         //3------------------------------------
        public Expression<Func<T, object>> OrderBy  {get; private set;}
        protected void AddOrderBy (Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;

        }
        //---------------------------------------3
       
       //4----------------------------------------
        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        protected void AddOrderByDescending (Expression<Func<T,object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;

        }
        //-------------------------------------------4

      

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IspagingEnabled {get; private set;}

       
      
      
        protected void ApplyPaging(int skip , int take)
        {
                Skip = skip;
                Take = take;
                IspagingEnabled = true;
        }


    }
}