using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarOwners.Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public double Expirience { get; set; }
        public ICollection<Car> Cars { get; set; }
        public Owner()
        {
            Cars = new List<Car>();
        }
        public override string ToString()
        {
            return Id.ToString() + " " + FirstName + " " + LastName + " " + Birthday + " " + Expirience.ToString();
        }
    }
}
