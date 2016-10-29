using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Entities;

namespace CarOwners.Domain.Abstract
{
    public interface IOwnersRepository
    {
        IQueryable<Owner> GetAll();
        Owner Get(int id);
        void Create(Owner item);
        void Update(Owner item);
        void Delete(int id);
    }
}
