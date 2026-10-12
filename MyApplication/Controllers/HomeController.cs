using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MyApplication.Models;


namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
