using QLCV_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.ViewModels
{
    public class qlcv_kehoachviewmodel
    {
        public long id { get; set; }
        [Display(Name ="Nội dung")]
        public string noidung { get; set; }
        [Display(Name ="Mô tả")]
        public string mota { get; set; }
        [Display(Name ="Ngày bắt đầu")]
        public DateTime ngaybd { get; set; }
        [Display(Name ="Ngày kết thúc")]
        public DateTime ngaykt { get; set; }
        [Display(Name ="Bộ phận")]
        public string bophan { get; set; }
        public qlcv_kehoach qlcv_kehoach { get; set; }
        public List<qlcv_kehoachviewmodel> listqlcv_kehoachVM { get; set; }
        public List<ns_dmbophan> ns_dmbophans { get; set; }
        //public List<qlcv_kehoachviewmodel> listqlcv_kehoachviewmodel { get; set; }
    }
}
