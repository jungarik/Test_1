using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CarOwners.Domain.Entities;
using CarOwners.Domain.Concrete;
using CarOwners.Domain.Abstract;

namespace CarOwners.Web.Controllers
{
    // Вообще код продублирован получился. так как в контроллерах Cars и Owners 
    // методы действия и представления имеют ту же реализацию за исключением типов Car & Owner
    // Стоит конечно обобщить это все и изменить путь с Cars/List и Owners/List на List/Cars и т.д.
    // А Сars и Owners обьединить в Моделе и работать тогда с моделью, выбирая подходящий тип с модели.
    // И добавить больше реализации запросов AJAX ( или WebAPI + Angular + JSON)
    // Композиция, "Стратегия", внедерения зависимостей и т.д. присутствуют в проекте
    public class OwnersController : Controller
    {
        IUnitOfWork unitOfWork;

        // .ctor
        public OwnersController(IUnitOfWork unitOfWork)// Здесь надо использовать DI Ninj
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Show Owners List
        public ActionResult List()
        {
            var owners = unitOfWork.Owners.GetAll().Include(o => o.Cars);
            return View(owners);
        }

        // GET: Send Information throuh AJAX
        // Return: Partial View for AJAX query
        public ActionResult Details(int id = 1)
        {
            Owner owner = unitOfWork.Owners.GetAll().Include(o => o.Cars).FirstOrDefault(o => o.Id == id);
            return PartialView("_Details", owner);
        }

        // GET: Edit Owner
        // Return: View. Show owners table and DropDownList for adding car to Owner
        public ActionResult Edit(int id = 1)
        {
            Owner owner = unitOfWork.Owners.GetAll().Include(o =>o.Cars).FirstOrDefault(o => o.Id == id);

            ViewBag.OwnerCars = "Cars:";

            IList<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var c in unitOfWork.Cars.GetAll())
            {
                if (owner.Cars.Contains<Car>(c) == false)
                {
                    selectList.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.ToString() });
                }
            }
            ViewBag.AllCars =selectList;
            if (owner == null)
                return HttpNotFound();
            return View(owner);
        }

        // POST: Edit Owner
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
            return View("Create", owner);
        }

        // GET: Create Owner
        public ActionResult Create()
        {
            return View(new Owner());
        }

        // POST: Create Owner
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            unitOfWork.Owners.Create(owner);
            unitOfWork.Save();
            var addedOwner = unitOfWork.Owners.GetAll().OrderByDescending(o => o.Id).FirstOrDefault();
            return RedirectToAction("Edit", new { id = addedOwner.Id });
        }

        // POST: Add car to Owner
        // Getting car from DropDownList, and add it to owner by owner id
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

        // GET: Delete Owner or just Owner's one Car
        public ActionResult Delete( int id = 1, int ItemId = 0 )
        {
            if (ItemId != 0)
            {
                Owner newCarOwner = unitOfWork.Owners.GetAll().Include(o => o.Cars).FirstOrDefault(o => o.Id == id);
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