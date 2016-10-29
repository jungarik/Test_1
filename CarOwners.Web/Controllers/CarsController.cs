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
            return PartialView("_Details", car);
        }
        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            Car car = unitOfWork.Cars.GetAll().Include(o => o.Owners).FirstOrDefault(o => o.Id == id);
            ViewBag.OwnerCars = "Owners:";

            IList<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var o in unitOfWork.Owners.GetAll())
            {
                if (car.Owners.Contains<Owner>(o) == false)
                {
                    selectList.Add(new SelectListItem { Value = o.Id.ToString(), Text = o.ToString() });
                }
            }
            ViewBag.AllOwners = selectList;
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car)
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

        public ActionResult Create()
        {
            return View(new Car());
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {
            unitOfWork.Cars.Create(car);
            unitOfWork.Save();
            var addedCar = unitOfWork.Cars.GetAll().OrderByDescending(o => o.Id).FirstOrDefault();
            return RedirectToAction("Edit", new { id = addedCar.Id });
        }

        [HttpPost]
        public ActionResult Add(int OwnerId, int id)
        {
            Owner owner = unitOfWork.Owners.Get(OwnerId);
            Car newOwnerCars = unitOfWork.Cars.Get(id);
            newOwnerCars.Owners.Add(owner);
            unitOfWork.Cars.Update(newOwnerCars);
            unitOfWork.Save();
            return RedirectToAction("Edit", new { id = id });
        }

        public ActionResult Delete(int id = 1, int ItemId = 0)
        {
            if (ItemId != 0)
            {
                //Car car = unitOfWork.Cars.Get(CarId);
                Car newOwnerCar = unitOfWork.Cars.GetAll().Include(c => c.Owners).FirstOrDefault(o => o.Id == id);
                //newCarOwner.Cars.Clear();
                Owner owner = unitOfWork.Owners.Get(ItemId);
                newOwnerCar.Owners.Remove(owner);
                unitOfWork.Cars.Update(newOwnerCar);
                unitOfWork.Save();
                return RedirectToAction("Edit", new { id = id });
            }
            else
            {
                unitOfWork.Cars.Delete(id);
                unitOfWork.Save();
                return RedirectToAction("List");
            }

        }
    }
}