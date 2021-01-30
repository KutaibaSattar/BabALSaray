using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.Project;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IProjectRepository
    {
       void Update(Project user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<ProjectDto>> GetProjectsAsync();

        Task<ProjectDto> GetProjectByIdAsync (int id);
                
        Task <ProjectDto> GetProjectByNameAsync (string projectname);
        Task <ProjectDto> GetProjectByDateStartAsync (string datestart);
        Task <ProjectDto> GetProjectByTeamSizeAsync (string teamsize);


        
    }
}