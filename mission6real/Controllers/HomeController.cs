using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mission6real_Smith.Models;
using static System.Net.Mime.MediaTypeNames;

namespace mission6real_Smith.Controllers
{
    public class HomeController : Controller
    {
        private MovieEnterContext _movieEnterContext;

        public HomeController(MovieEnterContext movieEnterContext)
        {
            _movieEnterContext = movieEnterContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewData["Categories"] = new SelectList(_movieEnterContext.Categories, "CategoryId", "CategoryName");

            return View(new Movie()); //Autofill movieId
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie forTheLulz)
        {
            if (ModelState.IsValid)
            {
                _movieEnterContext.Movies.Add(forTheLulz);

                _movieEnterContext.SaveChanges();

                return View("Confirmation", forTheLulz);
            }
            else
            {
                ViewBag.Categories = _movieEnterContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(forTheLulz);
            }
        }

        public IActionResult MovieList()
        {
            var movies = _movieEnterContext.Movies
                .Where(x=> x.Year >1887)
                .OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id) //this must match with the program.cs
        {
            Movie recordToEdit = _movieEnterContext.Movies
                .Single(x => x.MovieId == id); //note, this is .Single
            // var blah = context.Applications.Where gives a list,
            // but this gives a entityQueriable

            ViewBag.Categories = _movieEnterContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _movieEnterContext.Update(updatedInfo);
            _movieEnterContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Movie recordToDelete = _movieEnterContext.Movies
                .Single(x => x.MovieId == id); //note, this is .Single
            // var blah = context.Applications.Where gives a list,
            // but this gives a entityQueriable



            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedInfo)
        {
            _movieEnterContext.Movies.Remove(deletedInfo);
            _movieEnterContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
