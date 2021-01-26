using System;

namespace BabALSaray.AppEntities.Project
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public int TeamSize { get; set; }
        
    }
}