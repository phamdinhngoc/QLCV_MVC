using LibWebNetConn;
using QLCV_MVC.Models;
using QLCV_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLCV_MVC.Repository
{
    public class qlcv_cvkehoachRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();

        public DataSet GetAllDS()
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            DataSet ds = new DataSet();
            string sql = "Select a.*,b.noidung,nv.hoten,bp.ten from " + schema + ".qlcv_cvkehoach a left join " + schema + ".qlcv_kehoach b on a.idkehoach=b.id left join " + lib.user + ".ns_lilichnv nv on a.manv=nv.manv left join " + lib.user + ".ns_dmbophan bp on a.madv=bp.ma ";
            ds=lib.get_data(sql);
            return ds;
        }
        public List<qlcv_cvkehoachVM> GetAll()
        {
            List<qlcv_cvkehoachVM> qlcv_cvkehoachs = new List<qlcv_cvkehoachVM>();
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);

            //string sql = "select * from " + lib.user + lib.mmyy(ngay) + ".qlcv_kehoach ";
            string sql = "Select a.*,b.noidung as kehoach,nv.hoten,bp.ten from " + schema + ".qlcv_cvkehoach a left join " + schema + ".qlcv_kehoach b on a.idkehoach=b.id left join " + lib.user + ".ns_lilichnv nv on a.manv=nv.manv left join " + lib.user + ".ns_dmbophan bp on a.madv=bp.ma ";
            DataSet ds = new DataSet();
            ds = lib.get_data(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        qlcv_cvkehoachs.Add(new qlcv_cvkehoachVM()
                        {
                            id = Convert.ToInt64(ds.Tables[0].Rows[i]["id"].ToString()),
                            kehoach= ds.Tables[0].Rows[i]["kehoach"].ToString(),
                            noidung = ds.Tables[0].Rows[i]["noidung"].ToString(),
                            mota = ds.Tables[0].Rows[i]["mota"].ToString(),
                            ngaybd = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaybd"].ToString()),
                            ngaykt = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaykt"].ToString()),
                            diem = Convert.ToDecimal(ds.Tables[0].Rows[i]["diem"].ToString()),
                            hotennv = ds.Tables[0].Rows[i]["hoten"].ToString(),
                            bophan = ds.Tables[0].Rows[i]["ten"].ToString()
                        });
                    }
                }

            }
            return qlcv_cvkehoachs;
        }
        public qlcv_cvkehoach GetByIdModel(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            string sql = "select * from " + schema + ".qlcv_cvkehoach where id=" + id;
            DataSet ds = lib.get_data(sql);

            qlcv_cvkehoach qlcv_cvkehoach = new qlcv_cvkehoach
            {
                id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"].ToString()),
                idkehoach = Convert.ToInt64(ds.Tables[0].Rows[0]["idkehoach"].ToString()),
                noidung = ds.Tables[0].Rows[0]["noidung"].ToString(),
                mota = ds.Tables[0].Rows[0]["mota"].ToString(),
                ngaybd = Convert.ToDateTime(ds.Tables[0].Rows[0]["ngaybd"].ToString()),
                ngaykt = Convert.ToDateTime(ds.Tables[0].Rows[0]["ngaykt"].ToString()),
                diem = Convert.ToDecimal(ds.Tables[0].Rows[0]["diem"].ToString()),
                manv = ds.Tables[0].Rows[0]["manv"].ToString(),
                madv = ds.Tables[0].Rows[0]["madv"].ToString()
            };


            return qlcv_cvkehoach;
        }
        public List<ns_dmbophan> GetBoPhanById(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            List<ns_dmbophan> ns_dmbophans = new List<ns_dmbophan>();
            string sql = " select a.* from " + lib.user + ".ns_dmbophan a left join " + schema + ".qlcv_cvkehoach b on a.ma=b.madv where b.id=" + id;
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
        public List<ns_lilichnv> GetNhanVienById(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            List<ns_lilichnv> ns_lilichnvs = new List<ns_lilichnv>();
            string sql = " select a.manv,a.hoten,a.mabophan,a.ngaysinh from " + lib.user + ".ns_lilichnv a left join " + schema + ".qlcv_cvkehoach b on a.manv=b.manv where b.id=" + id;
            DataSet ds = lib.get_data(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ns_lilichnvs.Add(new ns_lilichnv
                {
                    manv = dr["manv"].ToString(),
                    hoten = dr["hoten"].ToString(),
                    mabophan = dr["mabophan"].ToString(),
                    ngaysinh = dr["ngaysinh"].ToString()
                });

            }
            return ns_lilichnvs;
        }
        public qlcv_cvkehoach AddNew(qlcv_cvkehoach _qlcv_cvkehoach)
        {
           
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            if (_qlcv_cvkehoach.id.ToString() == "") _qlcv_cvkehoach.id = 0;
            if (_qlcv_cvkehoach.id == 0)
            {
                _qlcv_cvkehoach.id = lib.getidyymmddhhmiss_stt_computer;

            }

            List<qlcv_cvkehoach> lst = new List<qlcv_cvkehoach>();
            lst.Add(_qlcv_cvkehoach);
            LibWebNetConn.AccessData.upd_int_table(lst, schema, "id");
            return _qlcv_cvkehoach;
        }
        public bool Delete(long id)
        {
            string ngay = lib.ngayhienhanh_server;
            string schema = lib.user + lib.mmyy(ngay);
            string sql = "delete from " + schema + ".qlcv_cvkehoach where id=" + id;
            bool upd = false;
            upd = lib.execute_data(sql);
            return upd;
        }
    }
}
