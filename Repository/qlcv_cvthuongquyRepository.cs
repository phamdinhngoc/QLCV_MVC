using LibWebNetConn;
using QLCV_MVC.Models;
using QLCV_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace QLCV_MVC.Repository
{
    public class qlcv_cvthuongquyRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();

        public IEnumerable<qlcv_cvthuongquy> GetAllDT()
        {
            List<qlcv_cvthuongquy> qlcv_cvthuongquys = new List<qlcv_cvthuongquy>();

            //string sql = " select a.*,b.ten from " + lib.user + ".qlcv_cvthuongquy a left join " + lib.user + ".ns_dmbophan b on a.madv=b.ma ";
            string sql = "select * from " + lib.user + ".qlcv_cvthuongquy ";

            DataSet ds = lib.get_data(sql);
            if(ds!= null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
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
                }
            }
           
            return qlcv_cvthuongquys;
        }
        public DataSet GetById(long id)
        {
            string sql = " select a.*,b.ten from " + lib.user + ".qlcv_cvthuongquy a left join " + lib.user + ".ns_dmbophan b on a.madv=b.ma where a.id=" + id;
            DataSet ds = lib.get_data(sql);
           
            return ds;
        }
        public DataSet GetAllDS()
        {
            string sql = "select * from " + lib.user + ".qlcv_cvthuongquy ";
            DataSet ds = lib.get_data(sql);
            return ds;
        }
        public qlcv_cvthuongquy AddNew(qlcv_cvthuongquy congviecthuongquy)
        {
            if(congviecthuongquy.Id == 0)
            {
                congviecthuongquy.Id = lib.getidyymmddhhmiss_stt_computer;
            }
           

            List<qlcv_cvthuongquy> lst = new List<qlcv_cvthuongquy>();
            lst.Add(congviecthuongquy);
            LibWebNetConn.AccessData.upd_int_table(lst, lib.user, "id");
            return congviecthuongquy;
        }
        public qlcv_cvthuongquy GetByIdModel(long id)
        {
            string sql = " select a.*,b.ten from " + lib.user + ".qlcv_cvthuongquy a left join " + lib.user + ".ns_dmbophan b on a.madv=b.ma where a.id=" + id;
            DataSet ds = lib.get_data(sql);
            
            qlcv_cvthuongquy qlcv_cvthuongquy = new qlcv_cvthuongquy
            {
                Id= Convert.ToInt64(ds.Tables[0].Rows[0]["id"].ToString()),
                Loai = Convert.ToInt32(ds.Tables[0].Rows[0]["loai"].ToString()),
                NoiDung = ds.Tables[0].Rows[0]["noidung"].ToString(),
                MoTa = ds.Tables[0].Rows[0]["mota"].ToString(),
                Diem = Convert.ToInt64(ds.Tables[0].Rows[0]["diem"].ToString()),
                MaDV = ds.Tables[0].Rows[0]["madv"].ToString()
            };
           

            return qlcv_cvthuongquy;
        }
        public List<ns_dmbophan> GetBoPhanById(long id)
        {
            List<ns_dmbophan> ns_dmbophans = new List<ns_dmbophan>();
            string sql = " select a.* from " + lib.user + ".ns_dmbophan a left join " + lib.user + ".qlcv_cvthuongquy b on a.ma=b.madv where b.id=" + id;
            DataSet ds = lib.get_data(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ns_dmbophans.Add(new ns_dmbophan
                {
                    Ma = dr["ma"].ToString(),
                    Ten = dr["ten"].ToString(),
                    MaNhom = dr["manhom"].ToString(),
                    SoThuTu = int.Parse(dr["sothutu"].ToString()),
                    userid = dr["userid"].ToString(),
                    makp = dr["makp"].ToString()

                });

            }
            return ns_dmbophans;
        }
        public bool Delete (long id)
        {
            string sql = "delete from " + lib.user + ".qlcv_cvthuongquy where id=" + id;
            bool upd = false;
            upd=lib.execute_data(sql);
            return upd;
        }

    }
}
