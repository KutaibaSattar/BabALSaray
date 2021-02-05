using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.Project;
using BabALSaray.Queries.Project;

namespace BabALSaray.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        
         Task<IEnumerable<Project>> GetAllProjects(ProjectQuery projectQuery);

     }

        
    }
