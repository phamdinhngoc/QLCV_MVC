using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCV_MVC.Models;
using QLCV_MVC.Repository;
using QLCV_MVC.ViewModels;
using System.Data;
using System.Linq;

namespace QLCV_MVC.Controllers
{
    public class qlcv_cvkehoachController : Controller
    {
        private readonly qlcv_cvkehoachRepository _qlcv_cvkehoachr;
        private readonly ns_dmbophanRepository _ns_dmbophanr;
        private readonly ns_lilichnvRepository _ns_lilichnvr;
        private readonly qlcv_kehoachRepository _qlcv_kehoachr;
        public qlcv_cvkehoachController(qlcv_cvkehoachRepository qlcv_cvkehoach, ns_dmbophanRepository ns_dmbophan,ns_lilichnvRepository ns_lilichnv,qlcv_kehoachRepository qlcv_kehoach)
        {
            _qlcv_cvkehoachr = qlcv_cvkehoach;
            _ns_dmbophanr = ns_dmbophan;
            _ns_lilichnvr = ns_lilichnv;
            _qlcv_kehoachr = qlcv_kehoach;
        }
        public IActionResult Index()
        {
           
           
            ViewBag.Name = "Add";
            qlcv_cvkehoachVM _viewmodel = new qlcv_cvkehoachVM();
            _viewmodel.listqlcv_cvkehoachVM = _qlcv_cvkehoachr.GetAll();
            ViewBag.MaDV = new SelectList(_ns_dmbophanr.GetAll(), "Ma", "Ten");
            ViewBag.MaNV = new SelectList(_ns_lilichnvr.GetAll(), "manv", "hoten");
            ViewBag.KeHoach = new SelectList(_qlcv_kehoachr.GetAll(), "id", "noidung");
            return View("Views/KeHoachCongViec/Index.cshtml", _viewmodel);
         }
        public IActionResult Edit(long id)
        {
          
            ViewBag.Name = "Update";
            ViewBag.MaDV = new SelectList(_ns_dmbophanr.GetAll(), "Ma", "Ten", _qlcv_cvkehoachr.GetByIdModel(id).madv);
            ViewBag.MaNV = new SelectList(_ns_lilichnvr.GetAll(), "manv", "hoten");
            ViewBag.KeHoach = new SelectList(_qlcv_kehoachr.GetAll(), "id", "noidung");
            var qlcv_cvkehoach = new qlcv_cvkehoachVM()
            {
                listqlcv_cvkehoachVM = _qlcv_cvkehoachr.GetAll().ToList(),
                qlcv_cvkehoach = _qlcv_cvkehoachr.GetByIdModel(id),
                listns_dmbophan = _qlcv_cvkehoachr.GetBoPhanById(id),
                listns_lilichnv = _qlcv_cvkehoachr.GetNhanVienById(id)
             
            };
            return View("Views/KeHoachCongViec/Index.cshtml", qlcv_cvkehoach);
        }
        public IActionResult Update(qlcv_cvkehoachVM qlcv_cvkehoachvm, long id)
        {

            _qlcv_cvkehoachr.AddNew(qlcv_cvkehoachvm.qlcv_cvkehoach);
            return RedirectToAction("Index");
        }
        public IActionResult Create(qlcv_cvkehoachVM _qlcv_cvkehoachVM)
        {
            _qlcv_cvkehoachr.AddNew(_qlcv_cvkehoachVM.qlcv_cvkehoach);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(long id)
        {
            ViewBag.Name = "Add";
            bool del_cvkehoach = false;
            del_cvkehoach = _qlcv_cvkehoachr.Delete(id);
            if (del_cvkehoach == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
