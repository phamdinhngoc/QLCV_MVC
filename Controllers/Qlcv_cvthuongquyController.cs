using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCV_MVC.Models;
using QLCV_MVC.Repository;
using QLCV_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static LibWebNetConn.AccessData;

namespace QLCV_MVC.Controllers
{
    public class Qlcv_cvthuongquyController : Controller
    {
        private readonly qlcv_cvthuongquyRepository _qlcv_cvthuongquy;
        private readonly ns_dmbophanRepository _ns_dmbophan;
        public Qlcv_cvthuongquyController(qlcv_cvthuongquyRepository qlcv_cvthuongquy,ns_dmbophanRepository ns_dmbophan)
        {
            _qlcv_cvthuongquy = qlcv_cvthuongquy;
            _ns_dmbophan = ns_dmbophan;
        }
        [BindProperty]
        public qlcv_cvthuongquy qlcv_cvthuongquy { get; set; }
        public List<qlcv_cvthuongquy> qlcv_cvthuongquys = new List<qlcv_cvthuongquy>();
        public qlcv_cvthuongquyviewmodel viewModel = new qlcv_cvthuongquyviewmodel();
        public viewmodel viewmodels = new viewmodel();
        public Loai loai { get; set; }
       
        public ActionResult Index1()
        {
           
            DataSet ds = _qlcv_cvthuongquy.GetAllDS();

            qlcv_cvthuongquys = (from DataRow dr in ds.Tables[0].Rows
                        select new qlcv_cvthuongquy()
                        {
                            Id = Convert.ToInt64(dr["id"]),
                            Loai = Convert.ToInt32(dr["loai"].ToString()),
                            NoiDung = dr["noidung"].ToString(),
                            MoTa = dr["mota"].ToString(),
                            Diem = Convert.ToDouble(dr["diem"]),
                            MaDV = dr["madv"].ToString()
                        }).ToList();
           
            return View("/Views/CongViecThuongQuy/Index.cshtml", qlcv_cvthuongquys);
        }
        //public ActionResult GetById(long id)
        //{
        //    //if (id > 0)
        //    //{
        //    //    DataSet ds = _qlcv_cvthuongquy.GetById(id);
        //    //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    //    {

        //    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //        {
        //    //            viewModel.qlcv_cvthuongquy = new qlcv_cvthuongquy()
        //    //            {
        //    //                Id = Convert.ToInt64(ds.Tables[0].Rows[i]["id"].ToString()),
        //    //                Loai = Convert.ToInt32(ds.Tables[0].Rows[i]["loai"].ToString()),
        //    //                NoiDung = ds.Tables[0].Rows[i]["noidung"].ToString(),
        //    //                MoTa = ds.Tables[0].Rows[i]["mota"].ToString(),
        //    //                Diem = Convert.ToDouble(ds.Tables[0].Rows[i]["diem"].ToString()),
        //    //                MaDV = ds.Tables[0].Rows[i]["madv"].ToString()
        //    //            };

        //    //        }

        //    //        viewModel.ns_dmbophans = _ns_dmbophan.GetAll();
        //    //    }

        //    //}
        //    if (id > 0)
        //    {
        //        DataSet ds = _qlcv_cvthuongquy.GetById(id);
        //        if (ds != null && ds.Tables[0].Rows.Count > 0)
        //        {

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                viewmodels.qlcv_cvthuongquy = new qlcv_cvthuongquy()
        //                {
        //                    Id = Convert.ToInt64(ds.Tables[0].Rows[i]["id"].ToString()),
        //                    Loai = Convert.ToInt32(ds.Tables[0].Rows[i]["loai"].ToString()),
        //                    NoiDung = ds.Tables[0].Rows[i]["noidung"].ToString(),
        //                    MoTa = ds.Tables[0].Rows[i]["mota"].ToString(),
        //                    Diem = Convert.ToDouble(ds.Tables[0].Rows[i]["diem"].ToString()),
        //                    MaDV = ds.Tables[0].Rows[i]["madv"].ToString()
        //                };

        //            }

        //            viewmodels.ns_dmbophans = _ns_dmbophan.GetAll();
        //        }

        //    }
        //    ViewData["viewModel"] = viewModel;
        //    return View("/Views/CongViecThuongQuy/Index.cshtml", viewmodels);
        //}
        [HttpGet]
        public ActionResult Index()
        {
            var cvthuongquy = new viewmodel()
            {
                qlcv_cvthuongquylist = _qlcv_cvthuongquy.GetAllDT().ToList(),
                ns_dmbophans = _ns_dmbophan.GetAll().ToList()
            };
            //ViewData["ns_dmbophan_id"] = new SelectList(_ns_dmbophan.GetAll(), "Ma", "Ten");
            return View("/Views/CongViecThuongQuy/Index.cshtml",cvthuongquy);
        }
        [HttpPost]
        public ActionResult Index(viewmodel _viewmodel)
        {
            if (_viewmodel.qlcv_cvthuongquy.Id == 0)
            {
                _qlcv_cvthuongquy.AddNew(_viewmodel.qlcv_cvthuongquy);
            }
            else
            {
                DataSet ds = _qlcv_cvthuongquy.GetById(_viewmodel.qlcv_cvthuongquy.Id);
                if(ds != null && ds.Tables[0].Rows.Count >0)
                {
                    viewmodels.qlcv_cvthuongquy = new qlcv_cvthuongquy()
                    {
                        Id=_viewmodel.qlcv_cvthuongquy.Id,
                        Loai = _viewmodel.qlcv_cvthuongquy.Loai,
                        NoiDung = _viewmodel.qlcv_cvthuongquy.NoiDung,
                        MoTa = _viewmodel.qlcv_cvthuongquy.MoTa,
                        Diem = _viewmodel.qlcv_cvthuongquy.Diem,
                        MaDV = _viewmodel.qlcv_cvthuongquy.MaDV
                    };
                    viewmodels.ns_dmbophans = _ns_dmbophan.GetAll();
                  
                }
                _qlcv_cvthuongquy.AddNew(viewmodels.qlcv_cvthuongquy);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            ViewBag.MaDV = new SelectList(_ns_dmbophan.GetAll(), "Ma", "Ten", _qlcv_cvthuongquy.GetByIdModel(id).MaDV);
            var cvthuongquydata = new viewmodel()
            {
                qlcv_cvthuongquylist = _qlcv_cvthuongquy.GetAllDT().ToList(),
                qlcv_cvthuongquy = _qlcv_cvthuongquy.GetByIdModel(id),
                ns_dmbophans = _qlcv_cvthuongquy.GetBoPhanById(id),
                
            };
            return View("/Views/CongViecThuongQuy/Index.cshtml", cvthuongquydata);
        }
        public ActionResult Delete(long id)
        {
            bool del_cvthuongquy = false;
            del_cvthuongquy=_qlcv_cvthuongquy.Delete(id);
            if (del_cvthuongquy == true)
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
