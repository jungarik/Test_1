using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Entities;
using CarOwners.Domain.Abstract;
using System.Data.Entity;

namespace CarOwners.Domain.Concrete
{
    public class CarRepository:IRepository<Car>
    {
        private CarOwnersContext db;

        public CarRepository(CarOwnersContext context)
        {
            this.db = context;
        }

        public IQueryable<Car> GetAll()
        {
            return db.Cars;
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);
        }

        public void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
                db.Cars.Remove(car);
        }
    }
}
