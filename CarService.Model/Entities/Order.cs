using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public bool IsDone { get; set; }

        public decimal InitialPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeclaredFinishDate { get; set; }

        public DateTime RealFinishDate { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<Avail> Avails { get; set; }

    }
}
