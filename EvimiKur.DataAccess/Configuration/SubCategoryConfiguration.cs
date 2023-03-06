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
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Status).IsRequired();


            builder.HasOne(x => x.Category).WithMany(x => x.SubCategories).HasForeignKey(x => x.CategoryId);
        }
    }
}
