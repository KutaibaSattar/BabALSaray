using System.Collections.Generic;
using System.Linq;
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
            
        
            return Ok(projects);


        }
       
       [HttpGet("search/{searchby}/{searchtext}")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> SearchProjects(string searchby, string searchtext)
        {
            
           
            var projects = await _context.Projects.Where(p => p.Id.ToString().Contains(searchtext)).ToListAsync();

            var returnProjects = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            
        
            return Ok(projects);


        }
       
       
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> AddProject(ProjectDto ProjectDto)
        {

           var projectToInsert = _mapper.Map<Project>(ProjectDto);
            
            _context.Projects.Add(projectToInsert);
           
            await _context.SaveChangesAsync();

             var result = _mapper.Map<Project, ProjectDto>(projectToInsert);

           
            return Ok(result);


        }

        [HttpPut]
        public async Task<ActionResult<ProjectDto>> UpdateProject(ProjectDto ProjectDto)
        {


            var projectToUpdate = await _context.Projects.FindAsync(ProjectDto.Id);



            if (projectToUpdate == null) return NotFound();

            _mapper.Map<ProjectDto, Project>(ProjectDto, projectToUpdate);


            await _context.SaveChangesAsync();

            var result = _mapper.Map<Project, ProjectDto>(projectToUpdate);

            
            return Ok(result);


        }
        [HttpDelete]

        public async Task<ActionResult> DeleteProject(int Id)
        {
            var project = await _context.Projects.FindAsync(Id);

            if (project == null)
            {
                return NotFound();
            } 
            
           _context.Projects.Remove(project) ;
           
           await _context.SaveChangesAsync();
           return Ok(Id);
          
           //return BadRequest("Faild to delete project !");

        }




    }
}