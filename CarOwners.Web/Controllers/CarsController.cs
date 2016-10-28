using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarOwners.Domain.Entities;
using CarOwners.Domain.Concrete;
using System.Data.Entity;

namespace CarOwners.Web.Controllers
{
    public class CarsController : Controller
    {
        UoW unitOfWork;

        public CarsController()// Здесь надо использовать DI Ninj
        {
            unitOfWork = new UoW();//Вместо этого
        }
        // GET: Cars
        public ActionResult List()
        {
            var cars = unitOfWork.Cars.GetAll();
            return View(cars);
        }

        public ActionResult Details(int id = 1)
        {
            Car car = unitOfWork.Cars.GetAll().Include(c => c.Owners).FirstOrDefault(c => c.Id == id);
            return View(car);
        }
        public ActionResult Edit(int id = 1)
        {
            Car car = unitOfWork.Cars.GetAll().Include(c => c.Owners).FirstOrDefault(c => c.Id == id);
            ViewBag.CarOwners = "Owners:";
            //Owner owner = unitOfWork.Owners.Get(id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car, Owner[] owners)
        {
            if (ModelState.IsValid)
            {
                if (car.Id == 0)
                {
                    unitOfWork.Cars.Create(car);
                    unitOfWork.Save();
                    return RedirectToAction("List");
                }
                else
                {
                    unitOfWork.Cars.Update(car);
                    unitOfWork.Save();
                    return RedirectToAction("List");
                }
            }
            return View(car);
        }
        public ViewResult Create()
        {
            return View("Edit", new Car());
        }
    }
}