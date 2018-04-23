using CarService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.EntityConfigurations
{
    public class AvailConfiguration : EntityTypeConfiguration<Avail>
    {
        public AvailConfiguration()
        {
            this.HasRequired(s => s.Order)
               .WithMany(o => o.Avails)
               .HasForeignKey(s => s.OrderId)
               .WillCascadeOnDelete(false);

            this.HasMany<Part>(s => s.UsedParts)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("AvailRefId");
                    cs.MapRightKey("PartRefId");
                    cs.ToTable("AvailPart");
                });

            this.HasRequired(s => s.Car)
                .WithMany()
                .HasForeignKey(o => o.CarId)
                .WillCascadeOnDelete(false);

            this.HasRequired(s => s.AvailStatus)
                .WithMany()
                .HasForeignKey(o => o.AvailStatusId)
                .WillCascadeOnDelete(false);

        }
    }
}
