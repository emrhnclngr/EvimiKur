using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Employee : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }

        //Relational Property


    }
}
