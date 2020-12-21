using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.Specifications;

namespace BabALSaray.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity // T to be usable by classes that derive from BaseEntity
    // only entities can be used with our generice
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetEntityWithSpec(ISpecifications<T> spec);

        Task<IReadOnlyList<T>> ListAsync (ISpecifications<T> spec);

        Task<int> CountAsync (ISpecifications<T> spec);
         
    }
}