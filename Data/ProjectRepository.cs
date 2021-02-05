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
using BabALSaray.Queries.Project;
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

        public async Task<IEnumerable<Project>> GetAllProjects(ProjectQuery projectQuery)
        {
            var query = _context.Projects.AsQueryable();
            query = query.Where(p => p.Id == projectQuery.Id.Value);

            return await query.ToListAsync();

        }
    }
}