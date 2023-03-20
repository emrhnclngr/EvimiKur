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
    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(300).IsRequired();
            builder.Property(x =>x.PhoneNumber).HasMaxLength(50).IsRequired();


            
        }
    }
}
