using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabALSaray.AppEntities.Project
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        
        
        public DateTime StartingDate { get ; set; }
        public int TeamSize { get; set; }

        [NotMapped]
        public string path
        {
            get => StartingDate.ToShortDateString();
          
               
        }

        
    }
}