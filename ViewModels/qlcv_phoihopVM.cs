using QLCV_MVC.Models;
using System.Collections.Generic;

namespace QLCV_MVC.ViewModels
{
    public class qlcv_phoihopVM
    {
        public long idkehoach { get; set; }
        public string madv { get; set; }
        public qlcv_phoihop qlcv_phoihop { get; set; }
        public IEnumerable<qlcv_kehoach> qlcv_kethoachs { get; set; }
        public List<ns_dmbophan> ns_dmbophans { get; set; }
    }
}
