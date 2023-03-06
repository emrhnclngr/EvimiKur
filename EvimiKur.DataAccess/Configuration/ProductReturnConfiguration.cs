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
    public class ProductReturnConfiguration : IEntityTypeConfiguration<ProductReturn>
    {
        public void Configure(EntityTypeBuilder<ProductReturn> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Order).WithMany(x => x.ProductReturns).HasForeignKey(x => x.OrderId);
        }
    }
}
