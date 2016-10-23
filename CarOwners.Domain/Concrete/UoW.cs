using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners.Domain.Concrete
{
    public class UoW:IDisposable
    {
        private CarOwnersContext db = new CarOwnersContext();
        private OwnerRepository ownerRepository;
        private CarRepository carRepository;

        public OwnerRepository Owners
        {
            get
            {
                if (ownerRepository == null)
                    ownerRepository = new OwnerRepository(db);
                return ownerRepository;
            }
        }

        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
