using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;
using System.Diagnostics;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        LinkGenerator _Linkgenerator;
        public IActionResult Index()
        {
            return View();
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
