namespace CarService.Model.Migrations
{
    using CarService.Core.Enums;
    using CarService.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarService.Model.CarServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarService.Model.CarServiceContext context)
       {
            var availStatusesToSave = new List<AvailStatus>() {
                new AvailStatus() { StatusName = AvailStatusEnum.WaitingForParts.GetStringValue() },
                new AvailStatus() { StatusName = AvailStatusEnum.NoWork.GetStringValue() },
                new AvailStatus() { StatusName = AvailStatusEnum.WorkInProgress.GetStringValue() },
                new AvailStatus() { StatusName = AvailStatusEnum.OrderingTheMissingParts.GetStringValue() },
                new AvailStatus() { StatusName = AvailStatusEnum.Finished.GetStringValue() }
            };
            foreach (var item in availStatusesToSave)
            {
                context.AvailStatuses.AddOrUpdate(o => o.StatusName, item);
            }          
            context.SaveChanges();
            var availstatus = context.AvailStatuses.FirstOrDefault(o => o.Id == 1); 

            var customerToSave = new Customer() { NameAndSurname = "Kamila Wróbel", NIP = "12345667", PhoneNumber = "51216193"};
            context.Customers.Add(customerToSave);
            context.SaveChanges();
            var customer = context.Customers.FirstOrDefault(o => o.NameAndSurname == "Kamila Wróbel");

            var carToSave = new Car() { Model = "Fruzia", CustomerId = customer.Id, Type = "sedan", Mark = "Renault", RegistrationNumber = "WWL3NK4", VIN = "1234" };
            context.Cars.Add(carToSave);
            context.SaveChanges();
            var car = context.Cars.FirstOrDefault(o => o.Model == "Fruzia");

            context.Orders.Add(new Order() { IsDone = false, InitialPrice = 232, OrderDate = new DateTime(2008, 5, 1), DeclaredFinishDate = new DateTime(2009, 10, 1), CustomerId = customer.Id }); //Avails = new List<Avail>() { avail } });
            context.SaveChanges();
            context.Orders.Add(new Order() { IsDone = false, InitialPrice = 282, OrderDate = new DateTime(2008, 5, 2), DeclaredFinishDate = new DateTime(2009, 10, 2), CustomerId = customer.Id }); //Avails = new List<Avail>() { avail } });
            context.SaveChanges();

            var usedPartsToSave = new List<Part>() { new Part() { IsReplacement = false, Manufacturer = "Stasiek", Name = "filtr", Price = 50 } };
            var usedPartsToSaveTwo = new List<Part>() { new Part() { IsReplacement = true, Manufacturer = "Karol Suska", Name = "ko³o", Price = 500 } };
            var availToSave = new Avail() { Duration = 3, Type = "Czyszczenie klimatyzacji", CarId = car.Id, UsedParts = usedPartsToSave, AvailStatusId = availstatus.Id, OrderId = 1 };
            var availToSaveTwo = new Avail() { Duration = 4, Type = "Wymiana ko³a", CarId = car.Id, UsedParts = usedPartsToSaveTwo, AvailStatusId = availstatus.Id, OrderId = 1};
            context.Avails.Add(availToSave);
            context.Avails.Add(availToSaveTwo);
            context.SaveChanges();
            //var avail = context.Avails.FirstOrDefault(o => o.Type == "Czyszczenie klimatyzacji");

           

            //context.Orders.Add(new Order() { IsDone = true, InitialPrice = 231, OrderDate = new DateTime(2016, 1, 1), DeclaredFinishDate = new DateTime(2016, 2, 15), CustomerId = customer.Id, Avails = new List<Avail>() { avail } });
            //context.SaveChanges();

            //context.Orders.Add(new Order() { IsDone = false, InitialPrice = 231, OrderDate = new DateTime(2016, 1, 1), DeclaredFinishDate = new DateTime(2015, 4, 1), CustomerId = customer.Id, Avails = new List<Avail>() { avail } });
            //context.SaveChanges();
        }
    }
}
