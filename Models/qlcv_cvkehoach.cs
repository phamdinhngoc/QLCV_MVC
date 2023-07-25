using System;
using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.Models
{
    public class qlcv_cvkehoach
    {
        public long id { get; set; }
        public long idkehoach { get; set; }
        public string noidung { get; set; }
        public string mota { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime  ngaybd { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime ngaykt { get; set; }
        public decimal diem { get; set; }
        public string manv { get; set; }
        public string madv { get; set; }
    }
}
