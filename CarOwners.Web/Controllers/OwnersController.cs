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
        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            Owner owner;
            if (id == 0)
            {
                owner = new Owner();
            }
            else
            { 
                owner = unitOfWork.Owners.GetAll().Include(o =>o.Cars).FirstOrDefault(o => o.Id == id);
            }
            ViewBag.OwnerCars = "Cars:";

            IList<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var c in unitOfWork.Cars.GetAll())
            {
                selectList.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.ToString() });
            }
            ViewBag.AllCars =selectList;
            if (owner == null)
                return HttpNotFound();
            return View(owner);
        }

        [HttpPost]
        public ActionResult Edit(Owner owner)
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

        public ActionResult Create()
        {
            return View(new Owner());
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            unitOfWork.Owners.Create(owner);
            unitOfWork.Save();
            var addedOwner = unitOfWork.Owners.GetAll().OrderByDescending(o => o.Id).FirstOrDefault();
            return RedirectToAction("Edit", new { id = addedOwner.Id });
        }

        [HttpPost]
        public ActionResult Add(int CarId, int id)
        {
            Car car = unitOfWork.Cars.Get(CarId);
            Owner newCarOwner = unitOfWork.Owners.Get(id);
            newCarOwner.Cars.Add(car);
            unitOfWork.Owners.Update(newCarOwner);
            unitOfWork.Save();
            return RedirectToAction("Edit", new { id = id });
        }

        public ActionResult Delete( int id = 1, int ItemId = 0 )
        {
            if (ItemId != 0)
            {
                //Car car = unitOfWork.Cars.Get(CarId);
                Owner newCarOwner = unitOfWork.Owners.GetAll().Include(o => o.Cars).FirstOrDefault(o => o.Id == id);
                //newCarOwner.Cars.Clear();
                Car car = unitOfWork.Cars.Get(ItemId);
                newCarOwner.Cars.Remove(car);
                unitOfWork.Owners.Update(newCarOwner);
                unitOfWork.Save();
                return RedirectToAction("Edit", new { id = id });
            }
            else
            {
                unitOfWork.Owners.Delete(id);
                unitOfWork.Save();
                return RedirectToAction("List");
            }
            
        }
    }
}