using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Domain.Common;
using SASSTS2.Domain.Entities;
using SASSTS2.Domain.Services.Abstraction;
using SASSTS2.Persistence.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Persistence.Context
{
    public class SASSTSContext : DbContext
    {
        private readonly ILoggedUserService _loggedUserService;
        public SASSTSContext(DbContextOptions<SASSTSContext> options, ILoggedUserService loggedUserService) : base(options)
        {
            _loggedUserService = loggedUserService;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRequest> ProductRequests { get; set; }
        public DbSet<PurchasedProduct> PurchasedProducts { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new BillMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());
            modelBuilder.ApplyConfiguration(new PriceOfferMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductRequestMapping());
            modelBuilder.ApplyConfiguration(new PurchasedProductMapping());
            modelBuilder.ApplyConfiguration(new PurchaseRequestMapping());
            modelBuilder.ApplyConfiguration(new WholesalerMapping());
            

            modelBuilder.Entity<Category>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Company>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Customer>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<PriceOffer>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<ProductRequest>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<PurchaseRequest>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Wholesaler>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var auditableEntries = ChangeTracker.Entries<AuditableEntity>().ToList();
            var deletetableEntries = ChangeTracker.Entries<DeletetableEntity>().ToList();

            foreach (var entry in auditableEntries)
            {

                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        //update
                        case EntityState.Modified:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy =  _loggedUserService.CustomerName +' '+ _loggedUserService.CustomerSurname + " - " + _loggedUserService.Email + " - " + _loggedUserService.Role ;
                            break;
                        //insert
                        case EntityState.Added:
                            auditableEntity.CreateDate = DateTime.Now;
                            auditableEntity.CreatedBy =  _loggedUserService.CustomerName + ' ' + _loggedUserService.CustomerSurname + " - " + _loggedUserService.Email  +" - " + _loggedUserService.Role ;
                            break;
                        default:
                            break;
                    }
                }

            }

            foreach (var entry in deletetableEntries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }

                if (entry.Entity is DeletetableEntity deletetableEntity)
                {
                    switch (entry.State)
                    {
                        //update
                        case EntityState.Modified:
                            deletetableEntity.ModifiedDate = DateTime.Now;
                            deletetableEntity.ModifiedBy =  _loggedUserService.CustomerName + ' ' + _loggedUserService.CustomerSurname + " - " + _loggedUserService.Email + " - " + _loggedUserService.Role;
                            break;
                        //insert
                        case EntityState.Added:
                            deletetableEntity.CreateDate = DateTime.Now;
                            deletetableEntity.CreatedBy =  _loggedUserService.CustomerName + ' ' + _loggedUserService.CustomerSurname + " - " + _loggedUserService.Email + " - " + _loggedUserService.Role;
                            break;
                        //delete
                        case EntityState.Deleted:
                            deletetableEntity.ModifiedDate = DateTime.Now;
                            deletetableEntity.ModifiedBy =  _loggedUserService.CustomerName + ' ' + _loggedUserService.CustomerSurname + " - " + _loggedUserService.Email + " - " + _loggedUserService.Role;
                            break;
                        default:
                            break;
                    }
                }

            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
