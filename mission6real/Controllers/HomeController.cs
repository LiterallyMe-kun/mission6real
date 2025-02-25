using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6real.Models;

namespace mission6real.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
