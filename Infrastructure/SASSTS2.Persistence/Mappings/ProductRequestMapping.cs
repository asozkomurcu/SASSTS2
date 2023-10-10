using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Persistence.Mappings
{
    public class ProductRequestMapping : DeletetableEntityMapping<ProductRequest>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<ProductRequest> builder)
        {
            builder.Property(x => x.PurchaseRequestId)
                .IsRequired()
                .HasColumnName("PURCHASE_REQUEST_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(4);

            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasColumnName("CUSTOMER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(5);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("PRODUCT_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(6);

            builder.Property(x => x.ProductDescription)
                .IsRequired()
                .HasColumnName("PRODUCT_DESCRIPTION")
                .HasColumnType("nvarchar(500)")
                .HasColumnOrder(7);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("AMOUNT")
                .HasColumnOrder(8);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductRequests)
                .HasForeignKey(x => x.ProductId)
                //.OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("PRODUCT_REQUEST_PRODUCT_PRODUCT_ID");

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.ProductRequests)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("PRODUCT_REQUEST_CUSTOMER_CUSTOMER_ID");

            builder.HasOne(x => x.PurchaseRequest)
                .WithOne(x => x.ProductRequest)
                .HasForeignKey<ProductRequest>(x => x.PurchaseRequestId);

            builder.ToTable("PRODUCT_REQUEST");
        }
    }
}
