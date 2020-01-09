using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace BussinesL
{
    public class Bussines
    {
        Data.CapaData data = new Data.CapaData();
        public List<ProductsEntity> ObtenerProductos()
        {
            var capaData = new Data.CapaData();
            List<ProductsEntity> ListaProductos = new List<ProductsEntity>();
            foreach (var item in capaData.GetProducts())
            {
                ProductsEntity Producto = new ProductsEntity()
                {
                    Id= item.Id,
                    IdBrand = item.IdBrand,
                    IdCatalog = item.IdCatalog,
                    IdColor = item.IdColor,
                    IdProvider = item.IdProvider,
                    IdType = item.IdType,
                    Tittle = item.Title,
                    Nombre = item.Nombre,
                    Description = item.Description,
                    Observations = item.Observations,
                    PriceDistributor = item.PriceDistributor,
                    PriceClient = item.PriceClient,
                    PriceMember = item.PriceMember,
                    IsEnabled = item.IsEnabled,
                    Keywords = item.Keywords,
                    DateUpdate = item.DateUpdate,
                    Image = item.ImagesProduct.Select(x=>x.Image).ToList(),
                };
                ListaProductos.Add(Producto);
            }
            return ListaProductos;
        }
        public void GuardarProducto(ProductsEntity model)
        {
            Products Producto = new Products();
            Producto.IdBrand = model.IdBrand;
            Producto.IdCatalog = model.IdCatalog;
            Producto.IdColor = model.IdColor;
            Producto.IdProvider = model.IdProvider;
            Producto.IdType = model.IdType;
            Producto.Title = model.Tittle;
            Producto.Nombre = model.Nombre;
            Producto.Description = model.Description;
            Producto.Observations = model.Observations;
            Producto.PriceClient = model.PriceClient;
            Producto.PriceDistributor = model.PriceDistributor;
            Producto.PriceMember = model.PriceMember;
            Producto.IsEnabled = model.IsEnabled;
            Producto.Keywords = model.Keywords;
            Producto.DateUpdate = DateTime.Now;
            var data = new Data.CapaData();
            data.SaveProduct(Producto);
        }

        public void DeleteProduct(int id)
        {
            var data = new Data.CapaData();
            data.DeleteProduct(id);
        }
        public ProductsEntity ShowProduct(int id)
        {
            var data = new Data.CapaData();
            var product = data.ShowProduct(id);
            ProductsEntity producto = new ProductsEntity();
            producto.Id = id;
            producto.IdBrand = product.IdBrand;
            producto.IdCatalog = product.IdCatalog;
            producto.IdColor = product.IdColor;
            producto.IdProvider = product.IdProvider;
            producto.IdType = product.IdType;
            producto.Nombre = product.Nombre;
            producto.Tittle = product.Title;
            producto.Description = product.Description;
            producto.Observations = producto.Observations;
            producto.PriceClient = product.PriceClient;
            producto.PriceDistributor = product.PriceDistributor;
            producto.PriceMember = product.PriceMember;
            producto.Image = product.ImagesProduct.Select(x=> x.Image).ToList();
            producto.IsEnabled = product.IsEnabled;
            producto.ImageP = product.ImagesProduct.Select(x => x.IdImage).ToList();
            producto.DateUpdate = producto.DateUpdate;
            return producto;
        }
        public void Edit(int id, ProductsEntity model)
        {
            Products Producto = new Products();
            Producto.Id = id;
            Producto.IdBrand = model.IdBrand;
            Producto.IdCatalog = model.IdCatalog;
            Producto.IdColor = model.IdColor;
            Producto.IdProvider = model.IdProvider;
            Producto.IdType = model.IdType;
            Producto.Title = model.Tittle;
            Producto.Nombre = model.Nombre;
            Producto.Description = model.Description;
            Producto.Observations = model.Observations;
            Producto.PriceClient = model.PriceClient;
            Producto.PriceDistributor = model.PriceDistributor;
            Producto.PriceMember = model.PriceMember;
            Producto.IsEnabled = model.IsEnabled;
            Producto.Keywords = model.Keywords;
            Producto.DateUpdate = DateTime.Now;
            var data = new Data.CapaData();
            data.EditProduct(Producto);
        }
        public void AddImage(byte[] img, int id)
        {
            ImagesProduct Img = new ImagesProduct()
            {
                IdImageProduct = id,
                Decription = "Image of product",
                Image = img,
                DateUpdate = DateTime.Now + "",
                IsEnabled = "true",
            };
            var data = new Data.CapaData();
            data.SaveImage(Img);
        }
        public List<ProductsEntity> searchByName(string search)
        {
            var productos = data.searchproduct(search);
            List<ProductsEntity> productosEncontrados = new List<ProductsEntity>();
            foreach (var item in productos)
            {
                productosEncontrados.Add(new ProductsEntity {
                    Id = item.Id,
                    IdBrand = item.IdBrand,
                    IdCatalog = item.IdCatalog,
                    IdColor = item.IdColor,
                    IdProvider = item.IdProvider,
                    IdType = item.IdType,
                    Tittle = item.Title,
                    Nombre = item.Nombre,
                    Description = item.Description,
                    Observations = item.Observations,
                    PriceDistributor = item.PriceDistributor,
                    PriceClient = item.PriceClient,
                    PriceMember = item.PriceMember,
                    IsEnabled = item.IsEnabled,
                    Keywords = item.Keywords,
                    DateUpdate = item.DateUpdate,
                    Image = item.ImagesProduct.Select(x => x.Image).ToList()
            });
            }
            return productosEncontrados;
        }
        public List<ProductsEntity> searchById(int id)
        {
            var producto = data.searchById(id);
            List<ProductsEntity> productoXid = new List<ProductsEntity>();
            foreach (var item in producto)
            {
                productoXid.Add(new ProductsEntity {
                    Id = item.Id,
                    IdType = item.IdType,
                    IdBrand = item.IdBrand,
                    IdCatalog = item.IdCatalog,
                    IdColor = item.IdColor,
                    IdProvider = item.IdProvider,
                    Nombre = item.Nombre,
                    Tittle = item.Title,
                    Description = item.Description,
                    Observations = item.Observations,
                    PriceDistributor = item.PriceDistributor,
                    PriceClient = item.PriceClient,
                    PriceMember = item.PriceMember,
                    IsEnabled = item.IsEnabled,
                    Keywords = item.Keywords,
                    DateUpdate = item.DateUpdate,
                    Image = item.ImagesProduct.Select(x => x.Image).ToList()
                });
            }
            return productoXid;
        }
        public IEnumerable<CatTypeProducts> GetTypeProduct()
        {
            var type = data.getTypeProduct();
            List<CatTypeProducts> tipodeProducto = new List<CatTypeProducts>();
            foreach (var item in type)
            {
                tipodeProducto.Add(new CatTypeProducts {
                    idType= item.IdType,
                    code = item.Code,
                    description = item.Description,
                    isEnabled = item.IsEnabled,
                    dateUpdate = item.DateUpdate
                });
            }
            return tipodeProducto.AsEnumerable();
        }
        public IEnumerable<CatBrandsProducts> GetCatBrands()
        {
            var type = data.getCatBrands();
            List<CatBrandsProducts> tipodeProducto = new List<CatBrandsProducts>();
            foreach (var item in type)
            {
                tipodeProducto.Add(new CatBrandsProducts
                {
                    idBrand = item.IdBrand,
                    code = item.Code,
                    name= item.Name,
                    description = item.Description,
                    isEnabled = item.IsEnabled,
                    dateUpdate = item.DateUpdate
                });
            }
            return tipodeProducto.AsEnumerable();
        }
        public IEnumerable<CatCatalogsProducts> GetCatCatalogs()
        {
            var type = data.getCatalogs();
            List<CatCatalogsProducts> tipodeProducto = new List<CatCatalogsProducts>();
            foreach (var item in type)
            {
                tipodeProducto.Add(new CatCatalogsProducts
                {
                    idCatalog = item.IdCatalog,
                    idProvider = item.IdProvider,
                    season = item.Season,
                    isEnabled = item.IsEnabled,
                    dateUpdate = item.DateUpdate,
                    starActiveDate = item.StarActiveDate,
                    endActiveDate = item.EndActiveDate
                });
            }
            return tipodeProducto.AsEnumerable();
        }
        public IEnumerable<CatColorsProducts> GetCatColors()
        {
            var type = data.getCatColors();
            List<CatColorsProducts> tipodeProducto = new List<CatColorsProducts>();
            foreach (var item in type)
            {
                tipodeProducto.Add(new CatColorsProducts
                {
                    idColor = item.IdColor,
                    name = item.Name,
                    description = item.Description,
                    isEnabled = item.IsEnable,
                    hexadecimal = item.HexaDecimal
                });
            }
            return tipodeProducto.AsEnumerable();
        }
        public IEnumerable<CatProvidersProducts> GetCatProviders()
        {
            var type = data.getCatProviders();
            List<CatProvidersProducts> tipodeProducto = new List<CatProvidersProducts>();
            foreach (var item in type)
            {
                tipodeProducto.Add(new CatProvidersProducts
                {
                    idProvider = item.IdProvider,
                    name = item.Name,
                    description = item.Description,
                    isEnabled = item.IsEnabled,
                    dateUpdate = item.DateUpdate,
                    url = item.Url
                });
            }
            return tipodeProducto.AsEnumerable();
        }
        public void DeleteImage(int idImage)
        {
            data.DeleteImage(idImage);
        }
    }
}
