using FoodWatch.Models.Food;
using FoodWatch.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWatch.WebMVC.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            var model = service.GetFoods();
            return View(model);
        }

        // GET: food/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: food/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFoodService();

            if (service.CreateFood(model))
            {
                TempData["SaveResult"] = "The food was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The food could not be created.");

            return View(model);
        }

        // get: food/details
        public ActionResult Details(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        //get: food/edit
        public ActionResult Edit(int id)
        {
            var service = CreateFoodService();
            var detail = service.GetFoodById(id);
            var model = new FoodEdit
            {
                FoodId = detail.FoodId,
                Name = detail.Name,
                ServingSize = detail.ServingSize,
                CostPerServing = detail.CostPerServing,
                CaloriesPerServing = detail.CaloriesPerServing,
                CarbsPerServing = detail.CarbsPerServing,
                ProteinPerServing = detail.ProteinPerServing,
                FatPerServing = detail.FatPerServing
            };
            return View(model);
        }

        //post: food/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodService();

            if (service.UpdateFood(model))
            {
                TempData["SaveResult"] = "The food was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The food could not be updated.");
            return View(model);
        }

        // get: food/delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodService();

            service.DeleteFood(id);

            TempData["SaveResult"] = "The food was deleted";

            return RedirectToAction("Index");
        }


        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            return service;
        }

    }
}