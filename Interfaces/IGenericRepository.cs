using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.Specifications;

namespace BabALSaray.Interfaces
{
    public interface IGenericRepository<T> where T: class // T to be usable by classes that derive from BaseEntity
    // only entities can be used with our generice
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetEntityWithSpec(IGenericQuery<T> spec);

        Task<IEnumerable<T>> ListAsync (IGenericQuery<T> spec);

         Task<IEnumerable<T>> ListAllAsync ();

        Task<int> CountAsync (IGenericQuery<T> spec);

        // above only reading
        /* None of these asynchronous methods.

        And the reason for this is that we're not going to be directly adding these to the database when we
        use any of these methods or we saying to entity framework when we use these is we want to add this.
        So track it or we want to update this.
        So track it and this is happening in memory it's not happening in a SQL databas or whatever
        database technology we're using our repository is not responsible for saving changes to the database
        that's left to our unit of work. */
        void Add (T entity);
        void Update(T entity );
        void Delete (T entity);

         
    }
}