using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Entities;

namespace CarOwners.Domain.Abstract
{
    public interface ICarsRepository
    {
        IQueryable<Car> GetAll();
        Car Get(int id);
        void Create(Car item);
        void Update(Car item);
        void Delete(int id);
    }
}
