using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarOwners.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public string Name { get; set; }

        //public int? TypeId { get; set; }

        //public CarType Type { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }
        public int Year { get; set; }

        public ICollection<Owner> Owners { get; set; }

        public Car()
        {
            Owners = new List<Owner>();
        }
        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + CarModel + " " + Price.ToString() + " " + Year.ToString();
        }
    }

    //public class CarType
    //{
    //    [HiddenInput(DisplayValue = false)]
    //    public int Id { get; set; }
    //    public string TypeName { get; set; }
    //    public ICollection<Car> Cars { get; set; }
    //    public CarType()
    //    {
    //        Cars = new List<Car>();
    //    }
    //}
}
