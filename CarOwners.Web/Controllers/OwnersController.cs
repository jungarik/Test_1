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
            ViewBag.OwnerCars = "Cars";
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
                if (owner.Id == 0)
                {
                    unitOfWork.Owners.Create(owner);
                    unitOfWork.Save();
                    return RedirectToAction("List");
                }
                else
                {
                    unitOfWork.Owners.Update(owner);
                    unitOfWork.Save();
                    return RedirectToAction("List");
                }
            }
            return View(owner);
        }
        public ViewResult Create()
        {
            return View("Edit", new Owner());
        }
    }
}