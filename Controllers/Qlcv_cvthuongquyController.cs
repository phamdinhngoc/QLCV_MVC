using Microsoft.AspNetCore.Mvc;
using QLCV_MVC.Models;
using QLCV_MVC.Repository;
using System.Collections.Generic;
using System.Linq;

namespace QLCV_MVC.Controllers
{
    public class Qlcv_cvthuongquyController : Controller
    {
        private readonly qlcv_cvthuongquyRepository _qlcv_cvthuongquy;
        public Qlcv_cvthuongquyController(qlcv_cvthuongquyRepository qlcv_cvthuongquy)
        {
            _qlcv_cvthuongquy = qlcv_cvthuongquy;
        }
        public IActionResult Index()
        {
            List<qlcv_cvthuongquy> qlcv_cvthuongquys = new List<qlcv_cvthuongquy>();

            qlcv_cvthuongquys = _qlcv_cvthuongquy.GetAll().ToList();

            return View("./CongViecThuongQuy/Index", qlcv_cvthuongquys);
            //return View(qlcv_cvthuongquys);
           
        }
    }
}
