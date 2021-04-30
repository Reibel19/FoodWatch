using FoodWatch.Models.Workout;
using FoodWatch.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWatch.WebMVC.Controllers
{
    public class WorkoutController : Controller
    {
        // GET: workout
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);
            var model = service.GetWorkouts();
            return View(model);
        }

        // GET: workout/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: workout/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateWorkoutService();

            if (service.CreateWorkout(model))
            {
                TempData["SaveResult"] = "The workout was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The workout could not be created.");

            return View(model);
        }

        // get: workout/details
        public ActionResult Details(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        //get: workout/edit
        public ActionResult Edit(int id)
        {
            var service = CreateWorkoutService();
            var detail = service.GetWorkoutById(id);
            var model = new WorkoutEdit
            {
                WorkoutId = detail.WorkoutId,
                Name = detail.Name,
                Time = detail.Time,
                Type = detail.Type,
                Intensity = detail.Intensity,
                Details = detail.Details
            };
            return View(model);
        }

        //post: workout/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkoutEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WorkoutId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWorkoutService();

            if (service.UpdateWorkout(model))
            {
                TempData["SaveResult"] = "The workout was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The workout could not be updated.");
            return View(model);
        }

        // get: workout/delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWorkoutService();

            service.DeleteWorkout(id);

            TempData["SaveResult"] = "The workout was deleted";

            return RedirectToAction("Index");
        }


        private WorkoutService CreateWorkoutService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);
            return service;
        }
    }
}