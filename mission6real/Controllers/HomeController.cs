using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6real_Smith.Models;

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
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie forTheLulz)
        {
            _movieEnterContext.Movies.Add(forTheLulz);

            _movieEnterContext.SaveChanges();

            return View("EnterMovie", forTheLulz);
        }
    }
}
