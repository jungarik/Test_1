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

        [Required(ErrorMessage = "Please enter a model")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        public string Type { get; set; }

       // [Range(typeof(decimal), "100.00", "1999999.99")]
        [Range(1, 1000000, ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        [Range(1900, 2017, ErrorMessage = "Invalid year")]
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
