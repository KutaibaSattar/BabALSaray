using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities.Project;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IProjectRepository _projectRepository;

        private readonly IMapper _mapper;
        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {

                      
            return Ok(await _projectRepository.GetProjectsAsync());


        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectById(int Id)
        {


            var projects = await _projectRepository.GetProjectByIdAsync(Id);

            var returnProjects = _mapper.Map<IEnumerable<ProjectDto>>(projects);


            return Ok(projects);


        }

         [HttpGet("{projectname}")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectByName(string projectname)
        {


            var projects = await _projectRepository.GetProjectByNameAsync(projectname);

            
            return Ok(projects);


        }


        [HttpPost]
        public async Task<ActionResult<ProjectDto>> AddProject(ProjectDto ProjectDto)
        {

           
            var projectToInsert = _mapper.Map<Project>(ProjectDto);

            _projectRepository.Update()
            _context.Projects.Add(projectToInsert);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Project, ProjectDto>(projectToInsert);


            return Ok(result);


        }

        [HttpPut]
        public async Task<ActionResult<ProjectDto>> UpdateProject(ProjectDto ProjectDto)
        {


           
            var projectToUpdate = await _projectRepository.GetProjectByIdAsync(ProjectDto.Id);

            
            if (projectToUpdate == null) return NotFound();

            _mapper.Map<ProjectDto, Project>(ProjectDto, projectToUpdate);


            await _projectRepository.SaveAllAsync();

            var result = _mapper.Map<Project, ProjectDto>(projectToUpdate);


            return Ok(result);


        }
        [HttpDelete]

        public async Task<ActionResult> DeleteProject(int Id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(Id);

            if (project == null) return NotFound();
           

            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();

            return Ok(Id);

            //return BadRequest("Faild to delete project !");

        }




    }
}