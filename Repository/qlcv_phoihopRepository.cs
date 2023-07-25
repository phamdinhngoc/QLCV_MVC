using LibWebNetConn;
using QLCV_MVC.Models;
using QLCV_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLCV_MVC.Repository
{
    public class qlcv_phoihopRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();

        //public List<qlcv_phoihop> GetAll()
        //{
        //    List<qlcv_phoihop> qlcv_phoihoplist = new List<qlcv_phoihop>();
        //    //qlcv_kethoach qlcv_kehoach = new qlcv_kethoach();
        //    string ngay = lib.ngayhienhanh_server;

        //    //string sql = "select * from " + lib.user + lib.mmyy(ngay) + ".qlcv_kethoach ";
        //    string sql = "select a.idkehoach,a.madv,b.ten,c.noidung from " + lib.user + "0823.qlcv_phoihop a left outer join " + lib.user + ".ns_dmbophan b on a.madv=b.ma ";
        //    sql += " left outer join " + lib.user + "0823.qlcv_kehoach c on a.idkehoach=c.id ";
        //    DataSet ds = new DataSet();
        //    ds = lib.get_data(sql);
        //    if (ds != null)
        //    {
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {

        //                qlcv_phoihoplist.Add(new qlcv_phoihop()
        //                {
        //                    idkehoach = Convert.ToInt64(ds.Tables[0].Rows[i]["idkehoach"].ToString()),
        //                    madv = ds.Tables[0].Rows[i]["madv"].ToString(),
        //                });
        //                qlcv_phoihoplist.Add(new qlcv_kethoach()
        //                {
                            
        //                });
        //            }
        //        }

        //    }
        //    return qlcv_phoihoplist;
        //}
        public List<qlcv_phoihopVM> GetAll()
        {
            List<qlcv_phoihopVM> qlcv_phoihoplist = new List<qlcv_phoihopVM>();
            string sql = "select a.idkehoach,a.madv,b.ten,c.noidung from " + lib.user + "0823.qlcv_phoihop a left outer join " + lib.user + ".ns_dmbophan b on a.madv=b.ma ";
            sql += " left outer join " + lib.user + "0823.qlcv_kehoach c on a.idkehoach=c.id ";
            DataSet ds = new DataSet();
            ds = lib.get_data(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //qlcv_phoihoplist.
                        //qlcv_phoihoplist.Add(new ns_dmbophan()
                        //{

                        //});
                        //qlcv_phoihoplist.Add(new qlcv_phoihop()
                        //{
                        //    idkehoach = Convert.ToInt64(ds.Tables[0].Rows[i]["idkehoach"].ToString()),
                        //    madv = ds.Tables[0].Rows[i]["madv"].ToString(),
                        //});
                        //qlcv_phoihoplist.Add(new qlcv_kethoach()
                        //{

                        //});
                    }
                }

            }
            return qlcv_phoihoplist;
        }
    }
}
