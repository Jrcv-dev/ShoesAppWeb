using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CatCatalogsProducts
    {
        public int idCatalog { get; set; }
        public int idProvider { get; set; }
        public string season { get; set; }
        public string starActiveDate { get; set; }
        public string endActiveDate { get; set; }
        public string dateUpdate { get; set; }
        public string isEnabled { get; set; }
    }
}
