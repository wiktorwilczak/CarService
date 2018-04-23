using CarService.Model.Entities;
using CarService.Service.DTOs.OpenOrderReportDTOs;

namespace CarService.Service
{
    public interface IOrderService
    {
        void AddOrder(Order order);

        void AddAvailToOrder(Avail avail, int id);

        void AddPartToOrderAvail(Part part, int orderId, int availId);

        OpenOrderReportDTO GetOpenOrderReport();
    }
}
