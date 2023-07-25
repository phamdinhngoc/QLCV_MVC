using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCV_MVC.Models;
using QLCV_MVC.Repository;
using QLCV_MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace QLCV_MVC.Controllers
{
    public class qlcv_kehoachController : Controller
    {
        private readonly qlcv_kehoachRepository _qlcv_kehoachr;
        private readonly ns_dmbophanRepository _ns_dmbophanr;
        public qlcv_kehoachController(qlcv_kehoachRepository qlcv_kehoachr,ns_dmbophanRepository ns_dmbophan)
        {
            _qlcv_kehoachr = qlcv_kehoachr;
            _ns_dmbophanr = ns_dmbophan;
        }

       
        public IActionResult Index()
        {
            ViewBag.Name = "Add";
            qlcv_kehoachviewmodel _viewmodel = new qlcv_kehoachviewmodel();
            _viewmodel.listqlcv_kehoachVM = _qlcv_kehoachr.GetAll();
            ViewBag.MaDV = new SelectList(_ns_dmbophanr.GetAll(), "Ma", "Ten");
            return View("Views/KeHoach/Index.cshtml", _viewmodel);
           
        }

        public IActionResult Create(qlcv_kehoachviewmodel qlcv_kehoachvm)
        {

            _qlcv_kehoachr.AddNew(qlcv_kehoachvm.qlcv_kehoach);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long id)
        {

            ViewBag.Name = "Update";
            ViewBag.MaDV = new SelectList(_ns_dmbophanr.GetAll(), "Ma", "Ten", _qlcv_kehoachr.GetByIdModel(id).madv);
            var qlcv_kehoachvm = new qlcv_kehoachviewmodel()
            {
                listqlcv_kehoachVM = _qlcv_kehoachr.GetAll().ToList(),
                qlcv_kehoach = _qlcv_kehoachr.GetByIdModel(id),
                ns_dmbophans = _qlcv_kehoachr.GetBoPhanById(id),
                
                //ns_dmbophans = _ns_dmbophan.GetById(qlcv_kethoach.)

            };
            return View("Views/KeHoach/Index.cshtml", qlcv_kehoachvm);
        }
        public IActionResult Update(qlcv_kehoachviewmodel qlcv_kehoachvm,long id)
        {

            _qlcv_kehoachr.AddNew(qlcv_kehoachvm.qlcv_kehoach);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(long id)
        {
            List<qlcv_cvkehoach> listqlcv_cvkehoach = new List<qlcv_cvkehoach>();
            ViewBag.Name = "Add";
            string message = string.Empty;
            if(id == 0 || id.ToString()=="")
            {
                TempData["Error"] = "Không tìm thấy";
                //return BadRequest("Không tìm thấy.");
            }
            else
            {
                listqlcv_cvkehoach = _qlcv_kehoachr.GetCVKeHoachById(id);
                if(listqlcv_cvkehoach.Count > 0)
                {
                    TempData["Error"] = "Không thể xóa!";
                    //message = "Không thể xóa kế hoạch này";
                }
                else
                {
                    bool del_kehoach = false;
                    del_kehoach = _qlcv_kehoachr.Delete(id);
                    if (del_kehoach == true)
                    {
                        TempData["Success"] = "Xóa thành công!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(message);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
