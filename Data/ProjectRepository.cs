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

      

    }
}