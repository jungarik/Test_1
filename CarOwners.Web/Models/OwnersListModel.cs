using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarOwners.Domain.Entities;

namespace CarOwners.Web.Models
{
    public class OwnersListModel
    {
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}