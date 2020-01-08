using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatBrandsProducts
    {
        public int idBrands { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isEnabled { get; set; }
        public DateTime dateUpdate { get; set; }
    }
}
