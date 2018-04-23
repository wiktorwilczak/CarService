using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.Entities
{
    public class Car
    {
        public int Id { get; set; }
        /// <summary>
        /// Nazwa jak np. Opel Corsa i Name-em jest Corsa a Mark Opel
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Combi, Sedan
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Opel,BMW...
        /// </summary>
        public string Mark { get; set; }

        public string VIN { get; set; }

        public string RegistrationNumber { get; set; }
  
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
