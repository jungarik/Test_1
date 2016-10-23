using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarOwners.Domain.Entities;

namespace CarOwners.Domain.Concrete
{
    public class CarOwnersContext : DbContext
    {
        public CarOwnersContext():base ("CarOwnersContext")
        { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasMany(o => o.Cars)
                .WithMany(c => c.Owners)
                .Map(t => t.MapLeftKey("OwnerId")
                .MapRightKey("CarId")
                .ToTable("OwnerCar"));
        }
    }
}
