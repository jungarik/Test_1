using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarOwners.Domain.Entities;

namespace CarOwners.Domain.Concrete
{
    public class OwnerDbInitializer: DropCreateDatabaseAlways<CarOwnersContext>
    {
        protected override void Seed(CarOwnersContext context)
        {
            Car c1 = new Car { Id = 1, Name = "BMW", CarModel = "M3", Price = 8000, Year = 2007 };
            Car c2 = new Car { Id = 2, Name = "Lexus", CarModel = "LX300", Price = 10000, Year = 2010 };
            Car c3 = new Car { Id = 3, Name = "Toyota", CarModel = "Rav 4", Price = 12000, Year = 2011 };
            Car c4 = new Car { Id = 4, Name = "Mercedes", CarModel = "CLK", Price = 50000, Year = 2012 };

            context.Cars.Add(c1);
            context.Cars.Add(c2);
            context.Cars.Add(c3);
            context.Cars.Add(c4);

            Owner o1 = new Owner
            {
                Id = 1,
                FirstName = "Igor",
                LastName = "Postilnyk",
                Birthday = new DateTime(1989, 9, 20),
                Expirience = 4,
                Cars = new List<Car>() { c1, c2, c3 }
            };
            Owner o2 = new Owner
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Birthday = new DateTime(1989, 9, 20),
                Expirience = 4,
                Cars = new List<Car>() { c4, c2, c3 }
            };
            Owner o3 = new Owner
            {
                Id = 1,
                FirstName = "Petr",
                LastName = "Petrov",
                Birthday = new DateTime(1989, 9, 20),
                Expirience = 4,
                Cars = new List<Car>() { c2, c3}
            };

            context.Owners.Add(o1);
            context.Owners.Add(o2);
            context.Owners.Add(o3);

            base.Seed(context);
        }
    }
}
