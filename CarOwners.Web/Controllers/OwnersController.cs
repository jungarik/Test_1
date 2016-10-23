using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CarOwners.Domain.Entities;
using CarOwners.Domain.Concrete;

namespace CarOwners.Web.Controllers
{
    public class OwnersController : Controller
    {
        UoW unitOfWork;
        public OwnersController()// Здесь надо использовать DI Ninj
        {
            unitOfWork = new UoW();//Вместо этого
        }
        // GET: Owners
        public ActionResult List()
        {
            var owners = unitOfWork.Owners.GetAll().Include(o => o.Cars).ToList();
            return View(owners);
        }

        public ActionResult Details(int id = 1)
        {
            Owner owner = unitOfWork.Owners.GetAll().Include(o => o.Cars).FirstOrDefault(o => o.Id == id);
            return View(owner);
        }
        public ActionResult Edit(int id = 1)
        {
            Owner owner = unitOfWork.Owners.GetAll().Include(o =>o.Cars).FirstOrDefault(o => o.Id == id);
            //Owner owner = unitOfWork.Owners.Get(id);
            if (owner == null)
                return HttpNotFound();
            return View(owner);
        }

        [HttpPost]
        public ActionResult Edit(Owner owner, Car[] cars)
        {
            if (ModelState.IsValid)
            {
                //if (owner.Id == 0)
                //{
                //    if (cars != null)
                //    {
                //        foreach (var car in cars)
                //        {
                //            unitOfWork.Cars.Create(car);
                //        }
                //        owner.Cars = cars.ToList<Car>();
                //    }
                //    unitOfWork.Owners.Create(owner);
                //    unitOfWork.Save();
                //    return RedirectToAction("Index");
                //}
                //else
                {
                    //Если была добавлена новая машина создать ее в базе
                    if (cars.Last().Id == 0)
                    {
                        unitOfWork.Cars.Create(cars.Last());
                        unitOfWork.Save();
                        owner.Cars = cars.ToList();
                    }

                    unitOfWork.Owners.Update(owner);
                    foreach (var c in cars)
                    {
                        unitOfWork.Cars.Update(c);
                    }
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(owner);
        }
    }
}