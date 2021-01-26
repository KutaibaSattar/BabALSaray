using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.Project;
using BabALSaray.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly DataContext _context;
        public ProjectsController(DataContext context)
        {
            _context = context;

        }

     [HttpGet]
     public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
      
      var projects = await _context.Projects.ToListAsync();

       return projects;


    }
     [HttpPost]
     public async Task<ActionResult<Project>> AddProject(Project project)
    {
      
      _context.Projects.Add(project);

       await _context.SaveChangesAsync();
       
       return Ok(project);


    }




}
}