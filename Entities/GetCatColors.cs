using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatColorsProducts
    {
        public int idColor { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string hexadecimal { get; set; }
        public bool isEnabled { get; set; }
    }
}
