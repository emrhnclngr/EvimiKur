using EvimiKur.Common.Enums;
using EvimiKur.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class AppUserCreateDto : IDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
