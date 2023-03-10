using EvimiKur.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EvimiKur.UI.Models
{
    public class AppUserCreateModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Status { get; set; }
    }
}
