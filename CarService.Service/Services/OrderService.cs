using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Model.Entities;
using CarService.Model;
using CarService.Core.Enums;
using AutoMapper;
using CarService.Service.DTOs.OpenOrderReportDTOs;

namespace CarService.Service
{
    public class OrderService : IOrderService
    {
        private readonly CarServiceContext _db;

        public OrderService(CarServiceContext db)
        {
            _db = db;
        }

        public void AddOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public void AddAvailToOrder(Avail avail, int id)
        {
            var foundOrder = _db.Orders.Find(id);
            foundOrder.Avails.Add(avail);
            _db.Entry(foundOrder).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

        }

        public void AddPartToOrderAvail(Part part, int orderId, int availId)
        {
            var foundOrder = _db.Orders.Find(orderId);
            var foundAvail = foundOrder.Avails.FirstOrDefault(o => o.Id == availId);
            foundAvail.UsedParts.Add(part);
            _db.Entry(foundOrder).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void CloseOrder(int orderId)
        {
            var foundOrder = _db.Orders.FirstOrDefault(o => o.Id == orderId);
            foundOrder.IsDone = true;
            _db.Entry(foundOrder).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public OpenOrderReportDTO GetOpenOrderReport()
        {
            var data = _db.Avails.Where(o => o.Order.IsDone == false);
            var dataDto = Mapper.Map<List<AvailDetailsOpenOrderReportDTO>>(data);

            var result = new OpenOrderReportDTO()
            {
                AvailDetails = dataDto,
                LaborTotalPrice = dataDto.Sum(o => o.LaborPrice)
            };
            return result;
        }
    }

  
}
