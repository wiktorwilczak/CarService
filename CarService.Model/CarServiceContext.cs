using CarService.Model.Entities;
using CarService.Model.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model
{
    public class CarServiceContext : DbContext
    {
        public CarServiceContext() : base("name=dbConnectionString")
  	    {
        }

        public DbSet<Avail> Avails { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<AvailStatus> AvailStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AvailConfiguration());
            modelBuilder.Configurations.Add(new CarConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Entity<Order>()
                .Property(c => c.DeclaredFinishDate)
                .HasColumnType("datetime2");
            modelBuilder.Entity<Order>()
               .Property(c => c.OrderDate)
               .HasColumnType("datetime2");
            modelBuilder.Entity<Order>()
               .Property(c => c.RealFinishDate)
               .HasColumnType("datetime2");
        }
    }
}
