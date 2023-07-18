using LibWebNetConn;
using QLCV_MVC.Models;
using QLCV_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLCV_MVC.Repository
{
    public class qlcv_cvthuongquyRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();

        public IEnumerable<qlcv_cvthuongquy> GetAll()
        {
            List<qlcv_cvthuongquy> qlcv_cvthuongquys = new List<qlcv_cvthuongquy>();

            string sql = " select a.*,b.ten from " + lib.user + ".qlcv_cvthuongquy a left join " + lib.user + ".ns_dmbophan b on a.madv=b.ma ";

            DataSet ds = lib.get_data(sql);
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                qlcv_cvthuongquy qlcv_cvthuongquy = new qlcv_cvthuongquy();
                qlcv_cvthuongquy.Id = Convert.ToInt64(ds.Tables[0].Rows[i]["ID"].ToString());
                qlcv_cvthuongquy.Loai = Convert.ToInt32(ds.Tables[0].Rows[i]["Loai"].ToString());
                qlcv_cvthuongquy.NoiDung = ds.Tables[0].Rows[i]["Noidung"].ToString();
                qlcv_cvthuongquy.MoTa = ds.Tables[0].Rows[i]["mota"].ToString();
                qlcv_cvthuongquy.Diem = Convert.ToDouble(ds.Tables[0].Rows[i]["diem"].ToString());
                qlcv_cvthuongquy.MaDV = ds.Tables[0].Rows[i]["madv"].ToString();

                qlcv_cvthuongquys.Add(qlcv_cvthuongquy);
            }
            return qlcv_cvthuongquys;
        }
    }
}
