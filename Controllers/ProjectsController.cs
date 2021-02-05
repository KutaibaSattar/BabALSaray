using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities.Project;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using BabALSaray.Queries.Project;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IunitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ProjectsController(IunitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects([FromQuery]ProjectQueryDto projectQueryDto)
        {

            var filter = _mapper.Map<ProjectQueryDto,ProjectQuery>(projectQueryDto);

           if (projectQueryDto.Id.HasValue)  return Ok(await _unitOfWork.Project.GetAllProjects(filter));  

          return Ok(await _unitOfWork.Project.GetAll());    
            


        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectById(int Id)
        {


            var projects = await _unitOfWork.Project.GetById(Id);

            var returnProjects = _mapper.Map<IEnumerable<ProjectDto>>(projects);


            return Ok(projects);


        }

        /* [HttpGet("{projectname}")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectByName(string projectname)
        {


            var projects = await _projectRepository.GetProjectByName(projectname);


            return Ok(projects);


        } */


        [HttpPost]
        public async Task<ActionResult<ProjectDto>> AddProject(ProjectDto ProjectDto)
        {


            var project = _mapper.Map<Project>(ProjectDto);

            _unitOfWork.Project.Add(project);



            if (await _unitOfWork.Complete() > 0)
            {
                var result = _mapper.Map<Project, ProjectDto>(project);
                return Ok(result);

            }

            return BadRequest("Problem addding project");
        }

        [HttpPut]
        public async Task<ActionResult<ProjectDto>> UpdateProject(ProjectDto ProjectDto)
        {


            var project = await _unitOfWork.Project.GetById(ProjectDto.Id);


            if (project == null) return NotFound();

            _mapper.Map(ProjectDto, project);


            await _unitOfWork.Complete();

            var result = _mapper.Map<Project, ProjectDto>(project);


            return Ok(result);


        }
        [HttpDelete]

        public async Task<ActionResult> DeleteProject(int Id)
        {
            var project = await _unitOfWork.Project.GetById(Id);

            if (project == null) return NotFound();

            _unitOfWork.Project.Remove(project);


            if (await  _unitOfWork.Complete() > 0)
            {

                return Ok(Id);

            }

            return BadRequest("Faild to delete project !");


        }




    }
}