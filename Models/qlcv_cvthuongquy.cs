using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.Models
{
    public class qlcv_cvthuongquy
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public int Loai { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Điểm")]
        public double Diem { get; set; }
        [Display(Name = "Bộ phận")]
        public string MaDV { get; set; }
    }
}
