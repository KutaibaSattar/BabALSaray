using System;
using System.Threading.Tasks;
using BabALSaray.AppEntities;

namespace BabALSaray.Interfaces
{
    public interface IunitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        IProjectRepository Project {get;}

         Task<int> Complete(); // number of changes in DB
    }
}