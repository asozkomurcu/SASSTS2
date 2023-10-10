using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Persistence.Mappings
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnOrder(1);


            ConfigureDerivedEntityMapping(builder);

            
        }
    }
}
