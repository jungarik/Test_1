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
        {}

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Create()
        //{
        //    return View("Edit", new Owner());
        //}
        //public PartialViewResult Add(int id = 1)
        //{
        //    var owner = unitOfWork.Owners.GetAll().Include(o => o.Cars).FirstOrDefault(m => m.Id == id);
        //    owner.Cars.Add(new Car { Name = "Name", CarModel = "Model"});
        //    //Car car = new Car();
        //    //unitOfWork.Cars.Create(car);
        //    return PartialView("_Add",owner);
        //}

        ////[HttpPost]
        ////public ActionResult Add(Car car, int id)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        unitOfWork.Cars.Create(car);
        ////        Owner owner = unitOfWork.Owners.Get(id);
        ////        owner.Cars.Add(car);
        ////        unitOfWork.Owners.Update(owner);
        ////        unitOfWork.Save();
        ////        return RedirectToAction("Edit");
        ////    }
        ////    return RedirectToAction("Index");
        ////}
        ////[HttpPost]
        ////public ActionResult Create(Owner owner)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        unitOfWork.Owners.Create(owner);
        ////        unitOfWork.Save();
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(owner);
        ////}

        //public ActionResult Edit(int id = 1)
        //{
        //    Owner owner = unitOfWork.Owners.GetAll().Include(o =>o.Cars).FirstOrDefault(o => o.Id == id);
        //    //Owner owner = unitOfWork.Owners.Get(id);
        //    if (owner == null)
        //        return HttpNotFound();
        //    return View(owner);
        //}

        //[HttpPost]
        //public ActionResult Edit(Owner owner, Car[] cars)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (owner.Id == 0)
        //        //{
        //        //    if (cars != null)
        //        //    {
        //        //        foreach (var car in cars)
        //        //        {
        //        //            unitOfWork.Cars.Create(car);
        //        //        }
        //        //        owner.Cars = cars.ToList<Car>();
        //        //    }
        //        //    unitOfWork.Owners.Create(owner);
        //        //    unitOfWork.Save();
        //        //    return RedirectToAction("Index");
        //        //}
        //        //else
        //        {
        //            //Если была добавлена новая машина создать ее в базе
        //            if (cars.Last().Id == 0)
        //            {
        //                unitOfWork.Cars.Create(cars.Last());
        //                unitOfWork.Save();
        //                owner.Cars = cars.ToList();
        //            }

        //            unitOfWork.Owners.Update(owner);
        //            foreach (var c in cars)
        //            {
        //                unitOfWork.Cars.Update(c);
        //            }
        //            unitOfWork.Save();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(owner);
        //}

        //public ActionResult Delete(int id)
        //{
        //    unitOfWork.Owners.Delete(id);
        //    unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}