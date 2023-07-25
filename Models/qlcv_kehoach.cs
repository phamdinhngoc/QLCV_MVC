using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.Models
{
    public class qlcv_kehoach
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Display(Name ="Nội dung")]
        public string noidung { get; set; }
        [Display(Name ="Mô tả")]
        public string mota { get; set; }
        [Display(Name ="Ngày bắt đầu")]
        public DateTime ngaybd { get; set; }
        [Display(Name ="Ngày kết thúc")]
        public DateTime ngaykt { get; set; }
        [Display(Name ="Đơn vị")]
        public string madv { get; set; }
        
    }
}
