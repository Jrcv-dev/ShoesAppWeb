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
                /*if(item.CatTypeProduct != null)
                {
                    Producto.CatTypeCode = item.CatTypeProduct.Code;
                }
                if(item.CatColors != null)
                {
                    Producto.NameColor = item.CatColors.Name;
                }
                if(item.CatBrands != null)
                {
                    Producto.CatBrandCode = item.CatBrands.Code;
                }
                if(item.CatProviders != null)
                {
                    Producto.CatProvidersName = item.CatProviders.Name;
                }
                if(item.CatCatalogs != null)
                {
                    Producto.CatCatalogSeason = item.CatCatalogs.Season;
                }*/
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
       /* public void DeleteImage(int id,ProductsEntity model)
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
            data.DeleteImage(Producto);
        }*/
    }
}
