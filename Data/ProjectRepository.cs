using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BabALSaray.AppEntities.Project;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {

        private readonly DataContext _context;
        public ProjectRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        
        public Task<IEnumerable<Project>> GetProjectByDateStart(DateTime datestart)
        {
            
            throw new NotImplementedException();
        }

        public Project GetProjectByName(string projectname)
        {
            
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectByTeamSize(int teamsize)
        {
            throw new NotImplementedException();
        }

        /* private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProjectRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectByDateStartAsync(DateTime datestart)
        {
            return await _context.Projects.Where(pd => pd.StartingDate == datestart)
                .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
           return await _context.Projects.FindAsync(id);
        }

        public async Task<ProjectDto> GetProjectByNameAsync(string projectname)
        {
             return await _context.Projects.Where(pn => pn.Name.Contains(projectname))
                 .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
                
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectByTeamSizeAsync(int teamsize)
        {
             return await _context.Projects.Where(pt => pt.TeamSize == teamsize)
                 .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
            return await _context.Projects.ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() >0 ;
        }

        public void Update(Project project) // marked entity it has been modified
        {
            _context.Entry(project).State = EntityState.Modified;
        }
 */

    }
}