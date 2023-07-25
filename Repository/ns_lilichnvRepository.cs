using LibWebNetConn;
using QLCV_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLCV_MVC.Repository
{
    public class ns_lilichnvRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();
        public List<ns_lilichnv> listns_lilichnv = new List<ns_lilichnv>();
        public List<ns_lilichnv> GetAll()
        {
            string sql = " select manv,hoten,ngaysinh,mabophan from " + lib.user + ".ns_lilichnv order by hoten";
            DataSet ds = lib.get_data(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                listns_lilichnv.Add(new ns_lilichnv
                {
                   
                    manv = dr["manv"].ToString(),
                    hoten = dr["hoten"].ToString(),
                    ngaysinh = dr["ngaysinh"].ToString()
                });

            }
            return listns_lilichnv;
        }
        
    }
}
