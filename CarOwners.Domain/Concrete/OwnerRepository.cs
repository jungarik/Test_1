using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Abstract;
using CarOwners.Domain.Entities;
using System.Data.Entity;

namespace CarOwners.Domain.Concrete
{
    public class OwnerRepository : IRepository<Owner>
    {
        private CarOwnersContext db;

        public OwnerRepository(CarOwnersContext context)
        {
            this.db = context;
        }

        public IQueryable<Owner> GetAll()
        {
            return db.Owners;
        }

        public Owner Get(int id)
        {
            return db.Owners.Find(id);
        }

        public void Create(Owner owner)
        {
            db.Owners.Add(owner);
        }

        public void Update(Owner owner)
        {
            db.Entry(owner).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner != null)
                db.Owners.Remove(owner);
        }
    }
}
