using System;
using System.Collections.Generic;

namespace BabALSaray.AppEntities
{
    public class dbAccounts
    {
        public int Id { get; set; }

        public string Key { get; set; }
        
        public string Name { get; set; }
       
                
        public int lvl { get; set; }

        public DateTime Created { get; set; }   = DateTime.Now;

        public DateTime LastActive { get; set; } =  DateTime.Now; 
    
        public dbAccounts Parent { get; set; }

       // Reference for self
        public int? ParentId {get;set;}
        public ICollection <dbAccounts> Children { get; set; }

        public Address Address {get;set;}
        
      
      /*   public dbAccounts(){

            Children = new Collection<dbAccounts>(); 

        } */

        
        
    }

    
}