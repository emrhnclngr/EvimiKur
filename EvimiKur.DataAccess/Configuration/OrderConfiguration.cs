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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(x => x.OrderDate).HasDefaultValueSql("getdate()").IsRequired();
            

            builder.HasOne(x => x.Supplier).WithMany(x => x.Orders).HasForeignKey(x => x.SupplierId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.AppUserId);

            

        }
    }
}
