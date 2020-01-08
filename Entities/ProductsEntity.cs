using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductsEntity
    {
        public int? Id { get; set; }
        public int? IdType { get; set; }
        public int? IdColor { get; set; }
        public int? IdBrand { get; set; }
        public int? IdProvider { get; set; }
        public int IdCatalog { get; set; }
        //cambiar string por list<tipodelatabla>
        public string CatTypeCode { get; set; }
        public string NameColor { get; set; }
        public string CatBrandCode { get; set; }
        public string CatProvidersName { get; set; }
        public string CatCatalogSeason { get; set; }
        public string Tittle { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; }
        public string Observations { get; set; }
        public decimal? PriceDistributor { get; set; }
        public decimal PriceClient { get; set; }
        public decimal PriceMember { get; set; }
        public bool IsEnabled { get; set; }
        public string Keywords { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<byte[]> Image { get; set; }
    }
}
