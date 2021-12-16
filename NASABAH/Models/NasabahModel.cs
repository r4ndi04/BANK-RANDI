using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NASABAH.Models
{
    public class NasabahModel
    {
        public string NO_KTP { get; set; }
        public string NAMA_LGKP { get; set; }
        public string ALAMAT { get; set; }
        public string TMPT_LAHIR { get; set; }
        public DateTime? TGL_LAHIR { get; set; }
        public string NO_HP { get; set; }
    }
}