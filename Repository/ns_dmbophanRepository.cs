using LibWebNetConn;
using QLCV_MVC.Models;
using System.Collections.Generic;
using System.Data;

namespace QLCV_MVC.Repository
{
    public class ns_dmbophanRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();
        public List<ns_dmbophan> ns_dmbophans = new List<ns_dmbophan>();
        public List<ns_dmbophan> GetAll()
        {
            string sql = " select * from " + lib.user + ".ns_dmbophan";
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
        public List<ns_dmbophan> GetById(string id)
        {
            // string sql = " select * from " + lib.user + ".ns_dmbophan where ma='" + id + "'";
            string sql = " select a.* from " + lib.user + ".ns_dmbophan where ma=" + id;
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
    }
}
