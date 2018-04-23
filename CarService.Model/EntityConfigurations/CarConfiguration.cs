using CarService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.EntityConfigurations
{
    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            this.HasMany<Order>(s => s.Orders)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("CarRefId");
                    cs.MapRightKey("OrderRefId");
                    cs.ToTable("CarOrder");
                });

            this.HasOptional(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .WillCascadeOnDelete(false);
        }

    }
}
