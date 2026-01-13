using MVC_CODE_FIRST.Models;
using MVC_CODE_FIRST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CODE_FIRST.Controllers
{
    public class MoviesController : Controller
    {
        MoviesDBContext db = new MoviesDBContext();
        IMovieRepository repo;

        public MoviesController()
        {
            repo = new MovieRepository(db);
        }


        // Create (GET)
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            repo.Add(movie);
            return RedirectToAction("Index");
        }

        // Edit (GET)
        public ActionResult Edit(int id)
        {
            var movie = repo.Get(id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        // Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            repo.Update(movie);
            return RedirectToAction("Index");
        }

        // Delete (GET) - confirmation
        public ActionResult Delete(int id)
        {
            var movie = repo.Get(id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        // Display movies released in a given year
        public ActionResult ByYear(int year)
        {
            var movies = repo.GetByYear(year);
            ViewBag.Year = year;
            return View(movies);
        }

        // Display all movies of a given director

        public ActionResult ListByDirector(string director = "XYZ")
        {
            ViewBag.Director = director;
            var movies = repo.GetByDirector(director);
            return View(movies);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db?.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}