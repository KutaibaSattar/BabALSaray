using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.Project;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetProjectByName (string projectname);
        Task<IEnumerable<Project>> GetProjectByDateStart (DateTime datestart);
        Task<IEnumerable<Project>> GetProjectByTeamSize (int teamsize);
      

        
    }
}