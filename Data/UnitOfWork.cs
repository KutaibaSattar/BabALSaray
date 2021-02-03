using System;
using System.Collections;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.Interfaces;
using Data;

namespace BabALSaray.Data
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly DataContext _context;
        private Hashtable _repositories; 
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Project =  new ProjectRepository(_context); 
        }
        public IProjectRepository Project {get; private set;}

       
        public async Task<int> Complete()
        {
           return await _context.SaveChangesAsync() ;
        }

        public void Dispose()
        {
            _context.Dispose();
        }



       // creating method repository of type TEntity
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories =  new Hashtable(); // checking if there is a hash table, if not creating one
           
            var type = typeof(TEntity).Name; // checking the name of Entity like (product......)

            if(!_repositories.ContainsKey(type)) // checking if repository (Hash table) contains that Entity type
           // if doesnt contain then
            {
               var  repositoryType = typeof(GenericRepository<>); // creating a repository type of generic repository 
              
               /* create an instance of this repository of the product  and pass in the context that we're going
                to get from our unit of work and then we add this repository to the hash table and then we return it. */
               var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance); // hash tabe store all repositories in used inside unit of work

            }
               return (IGenericRepository<TEntity>) _repositories[type];

        }

       
    }
}