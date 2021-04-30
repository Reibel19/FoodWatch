using FoodWatch.Models.Recipe;
using FoodWatch.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWatch.WebMVC.Controllers
{
    public class RecipeController : Controller
    {
        // GET: recipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipes();
            return View(model);
        }

        // GET: recipe/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: recipe/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "The recipe was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The recipe could not be created.");

            return View(model);
        }

        // get: recipe/details
        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        //get: recipe/edit
        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model = new RecipeEdit
            {
                RecipeId = detail.RecipeId,
                Name = detail.Name,
                TotalCalories = detail.TotalCalories,
                TotalCost = detail.TotalCost,
                TotalServings = detail.TotalServings,
                TotalCarbs = detail.TotalCarbs,
                TotalProtein = detail.TotalProtein,
                TotalFat = detail.TotalFat,
                CookTime = detail.CookTime,
                Instructions = detail.Instructions
            };
            return View(model);
        }

        //post: recipe/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "The recipe was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The recipe could not be updated.");
            return View(model);
        }

        // get: recipe/delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        //Post: recipe/delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRecipeService();

            service.DeleteRecipe(id);

            TempData["SaveResult"] = "The recipe was deleted";

            return RedirectToAction("Index");
        }


        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }




    }
}