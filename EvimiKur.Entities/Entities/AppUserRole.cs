using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class AppUserRole : BaseEntity
    {
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }

        //Relational Property

        public AppRole AppRole { get; set; }
        public AppUser AppUser { get; set; }



    }
}
