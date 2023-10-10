using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Persistence.Mappings
{
    public class DepartmentMapping : DeletetableEntityMapping<Department>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("COMPANY_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.DepartmentName)
                .IsRequired()
                .HasColumnName("DEPARTMENT_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(3);

            builder.Property(x=>x.CompanyName)
                .IsRequired()
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder (4);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("DEPARTMENT_COMPANY_COMPANY_ID");

            
            builder.ToTable("DEPARTMENTS");
        }
    }
}