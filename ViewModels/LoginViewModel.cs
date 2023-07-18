using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string userid { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string password_ { get; set; }
    }
}
