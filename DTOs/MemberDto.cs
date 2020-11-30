using System;

namespace BabALSaray.DTOs
{
    public class MemberDto
    {

       public int Id { get; set;}
       public string UserName { get; set;}

        public DateTime Created { get; set; }   = DateTime.Now;

        public DateTime LastActive { get; set; } =  DateTime.Now; 


        
        
    }
}