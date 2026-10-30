using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MyApplication.Models;
using MyApplication.Data;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyApplicationContext _context;
        public HomeController(ILogger<HomeController> logger, MyApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Product = _context.Products.ToList();
            return View(Product);
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
