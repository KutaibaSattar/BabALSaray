using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.Project;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IProjectRepository
    {
       void Update(Project project);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ProjectDto>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync (int id);
        Task <ProjectDto> GetProjectByNameAsync (string projectname);
        Task<IEnumerable<ProjectDto>> GetProjectByDateStartAsync (DateTime datestart);
        Task<IEnumerable<ProjectDto>> GetProjectByTeamSizeAsync (int teamsize);
        void AddProject(ProjectDto project);
        void DeleteMessage(ProjectDto message);


        
    }
}