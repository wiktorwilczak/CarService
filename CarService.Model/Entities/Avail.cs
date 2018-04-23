using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.Entities
{
    public class Avail      //usługa
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int Duration { get; set; }

        public int CarId { get; set; }

        public int AvailStatusId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Car Car { get; set; }

        public virtual List<Part> UsedParts { get; set; }

        public virtual AvailStatus AvailStatus { get; set; }
    }
}
