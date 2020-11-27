using System.Collections.Generic;

namespace AppEntities
{
    public class dbAccounts
    {
        public int Id { get; set; }

        public string Key { get; set; }
        
        public string Name { get; set; }
        public dbAccounts Parent { get; set; }
        
        public int lvl { get; set; }
        
        
        public ICollection <dbAccounts> Children { get; set; }
        
    }
}