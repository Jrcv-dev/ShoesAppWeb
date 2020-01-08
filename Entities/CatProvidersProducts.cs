using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatProvidersProducts
    {
        public int idProvider { get; set; }
        public string name { get; set; }
        public string description { get; set;}
        public string isEnabled { get; set; }
        public DateTime dateUpdate { get; set; }
        public string url { get; set; }
    }
}
