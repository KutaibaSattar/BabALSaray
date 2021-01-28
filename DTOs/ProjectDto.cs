using System;
using System.ComponentModel.DataAnnotations;

namespace BabALSaray.DTOs
{
    public class ProjectDto
    {   
        public int Id { get; set; }
        public string Name { get; set; }
       
        public DateTime StartingDate { get; set; }
        public int TeamSize { get; set; }

        public string path { get;set ;}
        
    }
}