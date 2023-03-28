using EvimiKur.Common.Enums;
using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace EvimiKur.Entities.Entities
{
    public class AppUser : BaseEntity
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        //public Role? Role { get; set; }         Enumla birlikte roller belirlenerek yapılacak.
        public Gender Gender { get; set; }       

        //Relational Property
        public List<AppUserRole> AppUserRoles { get; set; }
        public List<Order> Orders { get; set; }
        


    }
    
   
}
