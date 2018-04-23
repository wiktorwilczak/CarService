using CarService.Core.Enums;
using CarService.Model;
using CarService.Model.Entities;
using CarService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Service.Services
{
    public class AvailService : IAvailService
    {
        private readonly CarServiceContext _db;

        private readonly OrderService _orderService;

        public AvailService(CarServiceContext db, OrderService orderService)
        {
            _db = db;
            _orderService = orderService;
        }

        public void CloseAvail(int availId)
        {
            var foundAvail = _db.Avails.FirstOrDefault(o => o.Id == availId);

            var finishedStatusName = AvailStatusEnum.Finished.GetStringValue();

            var finishedStatusId = _db.AvailStatuses.FirstOrDefault(o => o.StatusName == finishedStatusName).Id;

            foundAvail.AvailStatusId = finishedStatusId;
            _db.Entry(foundAvail).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            CheckForAutoCompleteOrder(foundAvail.OrderId);
        }

        public void CheckForAutoCompleteOrder(int orderId)
        {
            var foundOrder = _db.Orders.FirstOrDefault(o => o.Id == orderId);

            if (!foundOrder.Avails.Any(o => o.AvailStatus.StatusName != AvailStatusEnum.Finished.GetStringValue()))
            {
                _orderService.CloseOrder(orderId);
            }
        }
    }
}
