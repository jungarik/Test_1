using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Concrete;

namespace CarOwners.Domain.Abstract
{
    public interface IRepositoryFactory
    {
        ICarsRepository CreateCarsRepository(CarOwnersContext context);
        IOwnersRepository CreateOwnersRepository(CarOwnersContext context);
    }
}
