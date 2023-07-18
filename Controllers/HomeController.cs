using Microsoft.AspNetCore.Mvc;
using QLCV_MVC.Models;
using QLCV_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QLCV_MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<LoginViewModel> loginViewModels = new List<LoginViewModel>();


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UserId()
        {
            return View();
        }

    }
}
