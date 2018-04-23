using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Service.Interfaces
{
    public interface IAvailService
    {
        void CloseAvail(int availId);

        void CheckForAutoCompleteOrder(int orderId);
    }
}
