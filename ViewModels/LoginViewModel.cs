using QLCV_MVC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLCV_MVC.ViewModels
{
    public class LoginViewModel
    {
        public List<ns_dlogin>  listns_dlogin { get; set; }
        public List<ns_lilichnv> listns_lilichnv { get; set; }
        public Account account { get; set; }
    }
}
