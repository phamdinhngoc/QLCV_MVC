using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.Models
{
    public class ns_dmbophan
    {
        public string Ma { get; set; }
        [Display(Name = "Tên bộ phận")]
        public string Ten { get; set; }
        public string MaNhom { get; set; }
        public int SoThuTu { get; set; }
        public string userid { get; set; }
        public string makp { get; set; }
    }
}
