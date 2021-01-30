using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.Project;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;

        }

        public Task<ProjectDto> GetProjectByDateStartAsync(string datestart)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectDto> GetProjectByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectDto> GetProjectByNameAsync(string projectname)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectDto> GetProjectByTeamSizeAsync(string teamsize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
           return await _context.Projects.ToListAsync();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Project user)
        {
            throw new System.NotImplementedException();
        }
    }
}