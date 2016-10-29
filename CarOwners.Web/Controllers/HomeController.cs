using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarOwners.Domain.Concrete;
using CarOwners.Domain.Entities;
using System.Data.Entity;

namespace CarOwners.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}