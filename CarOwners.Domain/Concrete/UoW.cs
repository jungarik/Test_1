using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Domain.Abstract;
using CarOwners.Domain.Entities;

namespace CarOwners.Domain.Concrete
{
    public class UoW: IUnitOfWork
    {
        // Агрегация
        private CarOwnersContext db = new CarOwnersContext();
        private IOwnersRepository ownerRepository;
        private ICarsRepository carRepository;

        IRepositoryFactory repoFactory;

        public UoW(IRepositoryFactory repoFactory)
        {
            this.repoFactory = repoFactory;
        }

        public IOwnersRepository Owners
        {
            get
            {
                if (ownerRepository == null)
                    // Агрегация
                    ownerRepository = repoFactory.CreateOwnersRepository(db);
                        //new OwnerRepository(db);
                return ownerRepository;
            }
        }

        public ICarsRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = repoFactory.CreateCarsRepository(db);
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
