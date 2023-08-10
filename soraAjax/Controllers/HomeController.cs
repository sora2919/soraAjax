using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soraAjax.Models;
using System.Diagnostics;

namespace soraAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult First()
        {
            return View();
        }

        public IActionResult GetDemo()
        {
            return View();
        }

        public IActionResult Travel()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Homework4()//HW4
        {
            return View();
        }

        public IActionResult Address() 
        {
            return View();

        }

        public IActionResult Promise()
        {
            return View();

        }

        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult Homework7()//HW7
        {
            return View();
        }

    }
}