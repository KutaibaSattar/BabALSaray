using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items); // From List<T>

        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }   

        public int PageSize { get; set; }

        public int TotalCount {get; set;} // Based on Query of Type

       /* A static method in C# is a method that keeps only one copy of the method at the Type level, 
       not the object level. That means, all instances of the class share the same copy of the method and its data.
        The last updated value of the method is shared among all objects of that Type. 
        Static methods are called by using the class name, not the instance of the class. */
 
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source , int pageNumber, int pageSize) 
        {
            var count = await source.CountAsync(); //From IQueryable
            var items = await source.Skip((pageNumber-1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items,count,pageNumber,pageSize);
        }
        
    }
}