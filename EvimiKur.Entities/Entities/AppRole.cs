using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }

        // Relational Property

        public List<AppUserRole> AppUserRoles { get; set; }
        
    }
}
