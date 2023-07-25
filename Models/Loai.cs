using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.Models
{
    public enum Loai
    {
        [Display(Name ="Thường")]
        thuong = 1,
        [Display(Name ="Trừ")]
        tru = 0
    }
}
