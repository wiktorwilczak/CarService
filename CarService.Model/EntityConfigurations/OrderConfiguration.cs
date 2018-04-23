using CarService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {

            this.HasRequired(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .WillCascadeOnDelete(false);
        }

    }
}
