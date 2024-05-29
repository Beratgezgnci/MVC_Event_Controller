using BE_105_Week09_Berat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BE_105_Week09_Berat.Controllers
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
