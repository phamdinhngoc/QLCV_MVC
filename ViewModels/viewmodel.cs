using QLCV_MVC.Models;
using System.Collections.Generic;

namespace QLCV_MVC.ViewModels
{
    public class viewmodel
    {
        public qlcv_cvthuongquy qlcv_cvthuongquy { get; set; }
        public List<qlcv_cvthuongquy> qlcv_cvthuongquylist { get; set; }
        public List<ns_dmbophan> ns_dmbophans { get; set; }
        public Loai Loai { get; set; }
       
    }
}
