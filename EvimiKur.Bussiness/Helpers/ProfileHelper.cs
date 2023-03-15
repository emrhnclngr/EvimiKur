using AutoMapper;
using EvimiKur.Bussiness.Mappings.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new AppUserProfile(),
                new ProductProfile(),
                new CategoryProfile(),
                new AppRoleProfile(),
                new ProductStatusProfile(),
            };
        }
    }
}
