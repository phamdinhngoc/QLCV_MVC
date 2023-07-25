using QLCV_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.ViewModels
{
    public class qlcv_cvkehoachVM
    {

        public long  id { get; set; }
        [Display(Name ="Kế hoạch")]
        public string kehoach { get; set; }
        [Display(Name ="Nội dung")]
        public string noidung { get; set; }
        [Display(Name ="Mô tả")]
        public  string  mota { get; set; }
        [Display(Name ="Ngày bắt đầu")]
        public DateTime ngaybd { get; set; }
        [Display(Name ="Ngày kết thúc")]
        public DateTime ngaykt { get; set; }
        [Display(Name ="Điểm")]
        public decimal diem { get; set; }
        [Display(Name ="Nhân viên")]
        public string hotennv { get; set; }
        [Display(Name ="Bộ phận")]
        public string bophan { get; set; }
        public qlcv_cvkehoach qlcv_cvkehoach { get; set; }
        public List<qlcv_cvkehoachVM> listqlcv_cvkehoachVM { get; set; }
        public List<ns_dmbophan> listns_dmbophan { get; set; }
        public List<ns_lilichnv> listns_lilichnv { get; set; }
        public List<qlcv_kehoach> listqlcv_kehoach { get; set; }
    }
}
