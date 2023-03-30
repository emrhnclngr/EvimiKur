using EvimiKur.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.DataAccess.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
          
            builder.Property(x => x.AddressDetail).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.Country).IsRequired();


            builder.HasOne(x => x.AppUser).WithMany(x => x.Addresses).HasForeignKey(x => x.AppUserId);


        }
    }
}
