using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class CatTypeProducts
    {
        public int idType { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public DateTime dateUpdate { get; set; }
        public bool isEnabled { get; set; }
    }
}
