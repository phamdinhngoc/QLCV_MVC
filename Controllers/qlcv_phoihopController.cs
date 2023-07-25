using Microsoft.AspNetCore.Mvc;
using QLCV_MVC.Repository;
using QLCV_MVC.ViewModels;
using System.Linq;

namespace QLCV_MVC.Controllers
{
    public class qlcv_phoihopController : Controller
    {
        private readonly qlcv_kehoachRepository _qlcv_kehoachr;
        private readonly ns_dmbophanRepository _ns_dmbophan;
        public qlcv_phoihopController(qlcv_kehoachRepository qlcv_kehoachr, ns_dmbophanRepository ns_dmbophan)
        {
            _qlcv_kehoachr = qlcv_kehoachr;
            _ns_dmbophan = ns_dmbophan;
        }

        public IActionResult Index(long id)
        {
            //ViewBag.Name = "Add";
            //qlcv_kehoachviewmodel _qlcv_kehoach = new qlcv_kehoachviewmodel();
            //if (id == 0)
            //{
            //    _qlcv_kehoach.qlcv_kehoachs = _qlcv_kehoachr.GetAll();
            //    _qlcv_kehoach.ns_dmbophans = _ns_dmbophan.GetAll().ToList();
            //}
            //else
            //{
            //    _qlcv_kehoach.qlcv_kehoachs = _qlcv_kehoachr.GetById(id);
            //}
            return View("/Views/KeHoach/Index.cshtml");
        }
    }
}
