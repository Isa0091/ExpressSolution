using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).HasMaxLength(50).IsRequired();
            b.Property(x => x.Name).HasMaxLength(300).IsRequired();
            b.OwnsOne(x => x.Logo).Property(x => x.MimeType).HasMaxLength(200);
            b.OwnsOne(x => x.Logo).Property(x => x.UrlMultimedia).HasMaxLength(500).IsRequired();
            b.OwnsOne(x => x.Logo).Property(x => x.Name).HasMaxLength(200);
            b.OwnsOne(x => x.Description).Property(x => x.Description).HasMaxLength(500).IsRequired();
            b.OwnsOne(x => x.Description).Property(x => x.ExtendedDescription).HasMaxLength(1500);

            b.OwnsMany(x => x.DynamicData, b2 =>
            {
                b2.WithOwner().HasForeignKey("CategoryId");
                b2.Property(x => x.DataName).IsRequired().HasMaxLength(50);
                b2.Property(x => x.DataValue).IsRequired();
                b2.HasKey("DataName", "CategoryId");
            });

        }
    }
}
