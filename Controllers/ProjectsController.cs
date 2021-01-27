using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities.Project;
using BabALSaray.Data;
using BabALSaray.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProjectsController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {

            var projects = await _context.Projects.ToListAsync();

            var returnProjects = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            
            return Ok(returnProjects);


        }
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> AddProject(ProjectDto project)
        {

           var addProject = _mapper.Map<Project>(project);
            
            _context.Projects.Add(addProject);
           
            await _context.SaveChangesAsync();

           
            return Ok(addProject);


        }

        [HttpPut]
        public async Task<ActionResult<ProjectDto>> UpdateProject(ProjectDto project)
        {


            var updatedProject = _context.Projects.Find(project.Id);



            if (updatedProject == null) return NotFound();

            _mapper.Map<ProjectDto, Project>(project, updatedProject);


            await _context.SaveChangesAsync();

            var result = _mapper.Map<Project, ProjectDto>(updatedProject);

            
            return Ok(result);


        }




    }
}