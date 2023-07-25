using LibWebNetConn;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using QLCV_MVC.Models;
using QLCV_MVC.ViewModels;

namespace QLCV_MVC.Repository
{
    
    public class qlcv_kehoachRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();
       

        //public List<qlcv_kehoach>GetAll()
        //{
        //    List<qlcv_kehoach> qlcv_kehoachs = new List<qlcv_kehoach>();
        //    string ngay = lib.ngayhienhanh_server;
        //    string schema = lib.user + "0823";//lib.mmyy(ngay);

        //    //string sql = "select * from " + lib.user + lib.mmyy(ngay) + ".qlcv_kehoach ";
        //    string sql = "select a.*,b.ten from " + schema + ".qlcv_kehoach a left join " + lib.user + ".ns_dmbophan b on a.madv=b.ma ";
        //    DataSet ds = new DataSet();
        //    ds=lib.get_data(sql);
        //    if(ds!=null)
        //    {
        //        if (ds.Tables[0].Rows.Count>0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {

        //                qlcv_kehoachs.Add(new qlcv_kehoach()
        //                {
        //                    Id = Convert.ToInt64(ds.Tables[0].Rows[i]["id"].ToString()),
        //                    noidung = ds.Tables[0].Rows[i]["noidung"].ToString(),
        //                    mota = ds.Tables[0].Rows[i]["mota"].ToString(),
        //                    ngaybd = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaybd"].ToString()),
        //                    ngaykt = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaykt"].ToString()),
        //                    madv = ds.Tables[0].Rows[i]["madv"].ToString()
        //                });
        //            }
        //        }
               
        //    }
        //    return qlcv_kehoachs;
        //}
        public List<qlcv_kehoachviewmodel> GetAll()
        {
            List<qlcv_kehoachviewmodel> qlcv_kehoachs = new List<qlcv_kehoachviewmodel>();
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);

            //string sql = "select * from " + lib.user + lib.mmyy(ngay) + ".qlcv_kehoach ";
            string sql = "Select a.*,bp.ten from " + schema + ".qlcv_kehoach a left join " + lib.user + ".ns_dmbophan bp on a.madv=bp.ma ";
            DataSet ds = new DataSet();
            ds = lib.get_data(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        qlcv_kehoachs.Add(new qlcv_kehoachviewmodel()
                        {
                            id = Convert.ToInt64(ds.Tables[0].Rows[i]["id"].ToString()),
                           
                            noidung = ds.Tables[0].Rows[i]["noidung"].ToString(),
                            mota = ds.Tables[0].Rows[i]["mota"].ToString(),
                            ngaybd = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaybd"].ToString()),
                            ngaykt = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaykt"].ToString()),
                           
                            bophan = ds.Tables[0].Rows[i]["ten"].ToString()
                        });
                    }
                }

            }
            return qlcv_kehoachs;
        }
        public List<qlcv_kehoach> GetById(long id)
        {
            List<qlcv_kehoach> qlcv_kehoachs = new List<qlcv_kehoach>();

            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + "0823";//lib.mmyy(ngay);

            //string sql = "select * from " + lib.user + lib.mmyy(ngay) + ".qlcv_kehoach ";
            string sql = "select * from " + schema + ".qlcv_kehoach where id=" + id;
            DataSet ds = new DataSet();
            ds = lib.get_data(sql);
            if (ds.Container != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        qlcv_kehoachs.Add(new qlcv_kehoach()
                        {
                            Id = Convert.ToInt64(ds.Tables[0].Rows[i]["id"].ToString()),
                            noidung = ds.Tables[0].Rows[i]["noidung"].ToString(),
                            mota = ds.Tables[0].Rows[i]["mota"].ToString(),
                            ngaybd = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaybd"].ToString()),
                            ngaykt = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaykt"].ToString()),
                            madv = ds.Tables[0].Rows[i]["madv"].ToString()
                        });
                    }
                }

            }
            return qlcv_kehoachs;
        }
        public qlcv_kehoach GetByIdModel(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            string sql = "select * from " + schema + ".qlcv_kehoach where id=" + id;
            DataSet ds = lib.get_data(sql);

            qlcv_kehoach qlcv_kehoach = new qlcv_kehoach
            {
                Id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"].ToString()),
                noidung = ds.Tables[0].Rows[0]["noidung"].ToString(),
                mota = ds.Tables[0].Rows[0]["mota"].ToString(),
                ngaybd = Convert.ToDateTime(ds.Tables[0].Rows[0]["ngaybd"].ToString()),
                ngaykt = Convert.ToDateTime(ds.Tables[0].Rows[0]["ngaykt"].ToString()),
                madv = ds.Tables[0].Rows[0]["madv"].ToString()
            };


            return qlcv_kehoach;
        }
        public List<ns_dmbophan> GetBoPhanById(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            List<ns_dmbophan> ns_dmbophans = new List<ns_dmbophan>();
            string sql = " select a.* from " + lib.user + ".ns_dmbophan a left join " + schema + ".qlcv_kehoach b on a.ma=b.madv where b.id=" + id;
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
        public List<qlcv_cvkehoach> GetCVKeHoachById(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            List<qlcv_cvkehoach> listqlcv_cvkehoach = new List<qlcv_cvkehoach>();
            string sql = " select * from " + schema + ".qlcv_cvkehoach a left join " + schema + ".qlcv_kehoach b on a.idkehoach=b.id where b.id=" + id;
            DataSet ds = lib.get_data(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                listqlcv_cvkehoach.Add(new qlcv_cvkehoach
                {
                    id = Convert.ToInt64(dr["id"].ToString()),
                    idkehoach = Convert.ToInt64(dr["id"].ToString()),
                    noidung = dr["noidung"].ToString(),
                    mota = dr["mota"].ToString(),
                    ngaybd =Convert.ToDateTime(dr["ngaybd"].ToString()),
                    ngaykt = Convert.ToDateTime(dr["ngaykt"].ToString()),
                    diem = Convert.ToDecimal(dr["diem"].ToString()),
                    manv = dr["manv"].ToString(),
                    madv= dr["madv"].ToString(),
                }) ;

            }
            return listqlcv_cvkehoach;
        }
        public qlcv_kehoach AddNew(qlcv_kehoach _qlcv_kehoach)
        {
            
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            if (_qlcv_kehoach.Id.ToString() == null) _qlcv_kehoach.Id = 0;
            if (_qlcv_kehoach.Id == 0)
            {
                _qlcv_kehoach.Id = lib.getidyymmddhhmiss_stt_computer;
               
            } 
            
            List<qlcv_kehoach> lst = new List<qlcv_kehoach>();
            lst.Add(_qlcv_kehoach);
            LibWebNetConn.AccessData.upd_int_table(lst, schema , "id");
            return _qlcv_kehoach;
        }
        public bool Delete(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            
            string sql = "delete from " + schema + ".qlcv_kehoach where id=" + id;
            bool upd = false;
            upd = lib.execute_data(sql);
            return upd;
        }

    }
}
