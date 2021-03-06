using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data.Mapping
{
    public class StoreMap : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).HasMaxLength(50).IsRequired();
            b.Property(x => x.Name).HasMaxLength(300).IsRequired();
            b.OwnsOne(x => x.Description).Property(x => x.Description).HasMaxLength(500).IsRequired();
            b.OwnsOne(x => x.Description).Property(x => x.ExtendedDescription).HasMaxLength(1500);


            b.OwnsMany(x => x.DynamicData, b2 =>
            {
                b2.WithOwner().HasForeignKey("StoreId");
                b2.Property(x => x.DataName).IsRequired().HasMaxLength(50);
                b2.Property(x => x.DataValue).IsRequired();
                b2.HasKey("DataName", "StoreId");
            });

            //contactos
            b.OwnsMany(x => x.Contacts, Contact => {
                Contact.HasKey(x => x.Id);
                Contact.Property(x => x.Id).HasMaxLength(50);
                Contact.Property(x => x.StoreId).HasMaxLength(50);
                Contact.WithOwner().HasForeignKey(x => x.StoreId);
                Contact.OwnsOne(x => x.ContactData).Property(x => x.Email).HasMaxLength(200);
                Contact.OwnsOne(x => x.ContactData).Property(x => x.LandLineNumber).HasMaxLength(50);
                Contact.OwnsOne(x => x.ContactData).Property(x => x.MobileNumber).HasMaxLength(50);
                Contact.OwnsOne(x => x.ContactData).Property(x => x.Name).HasMaxLength(300).IsRequired();
            });

            //categorias
            b.OwnsMany(x => x.StoreCategories, StoreCategory => {
                StoreCategory.HasKey(x => new { x.CategoryId, x.StoreId});
                StoreCategory.Property(x => x.CategoryId).HasMaxLength(50);
                StoreCategory.Property(x => x.StoreId).HasMaxLength(50);
                StoreCategory.WithOwner().HasForeignKey(x => x.StoreId);
                StoreCategory.HasOne("Category").WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Restrict);

            });

            //Multimedias
            b.OwnsMany(x => x.Multimedia, multimedia => {
                multimedia.HasKey(x => x.Id);
                multimedia.Property(x => x.Id).HasMaxLength(50);
                multimedia.Property(x => x.StoreId).HasMaxLength(50);
                multimedia.WithOwner().HasForeignKey(x => x.StoreId);
                multimedia.OwnsOne(x => x.DataMultimedia).Property(x => x.MimeType).HasMaxLength(200);
                multimedia.OwnsOne(x => x.DataMultimedia).Property(x => x.UrlMultimedia).HasMaxLength(500).IsRequired();
                multimedia.OwnsOne(x => x.DataMultimedia).Property(x => x.Name).HasMaxLength(200);
            });

        }
    }
}
