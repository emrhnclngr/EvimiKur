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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.CompanyName).IsRequired();
            builder.Property(x => x.ContactName).IsRequired();
            builder.Property(x => x.ContactTitle).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.PostalCode).IsRequired();
            

        }
    }
}
