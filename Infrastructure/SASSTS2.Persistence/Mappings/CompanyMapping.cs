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
    public class CompanyMapping : DeletetableEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);
        }
    }
}
