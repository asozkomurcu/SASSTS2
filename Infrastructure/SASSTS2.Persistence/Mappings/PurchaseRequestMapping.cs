using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Persistence.Mappings
{
    public class PurchaseRequestMapping : DeletetableEntityMapping<PurchaseRequest>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<PurchaseRequest> builder)
        {
            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasColumnName("CUSTOMER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(3);

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnOrder(4);

            builder.HasOne(x => x.Customer)
               .WithMany(x => x.PurchaseRequests)
               .HasForeignKey(x => x.CustomerId)
               .HasConstraintName("PURCHASE_REQUEST_CUSTOMER_CUSTOMER_ID");

            builder.ToTable("PURCHASE_REQUEST");
        }
    }
}
