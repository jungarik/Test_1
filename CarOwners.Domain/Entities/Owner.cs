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

        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Invalid date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Range(1, 50, ErrorMessage = "Invalid expirience")]
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
