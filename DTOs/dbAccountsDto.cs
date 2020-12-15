using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class dbAccountsDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Key { get; set; }

        public string Name { get; set; }


        public int lvl { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public int? ParentId { get; set; }

        public ICollection<dbAccountsDto> Children { get; set; }
        /*  public dbAccountsDto(){

             Children = new Collection<dbAccountsDto>();

         } */


    }
}