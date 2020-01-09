using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data
{
    public class CapaData
    {
        DataProductsEntities ctx = new DataProductsEntities();

        public List<Products> GetProducts()
        {
            List<Products> ListaProductos = new List<Products>();
            var products = ctx.Products.Include(p => p.CatBrands)
                .Include(p => p.CatCatalogs)
                .Include(p => p.CatColors)
                .Include(p => p.CatProviders)
                .Include(p => p.CatTypeProduct);
            return products.ToList();
        }
        public void SaveProduct(Products model)
        {
            try
            {
                ctx.Products.Add(model);
                ctx.SaveChanges();
            }
            catch (System.Exception e)
            {

            }
        }
        public void DeleteProduct(int id)
        {
            try
            {
                List<ImagesProduct> ListImages = new List<ImagesProduct>();
                ListImages = (from o in ctx.ImagesProduct where o.IdImageProduct == id select o).ToList();
                var registro = (from o in ctx.Products where o.Id == id select o).First();
                if (registro != null)
                {
                    ctx.ImagesProduct.RemoveRange(ListImages);
                    ctx.Products.Remove(registro);
                    ctx.SaveChanges();
                }

            }
            catch (System.Exception e)
            {
                throw;
            }
        }
        public Products ShowProduct(int id)
        {
            var producto = (from o in ctx.Products where o.Id == id select o).First();
            return producto;
        }
        public void EditProduct(Products model)
        {
            try
            {
                ctx.Entry(model).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (System.Exception e)
            {

            }
        }
        public void SaveImage(ImagesProduct Img)
        {
            try
            {
                ctx.ImagesProduct.Add(Img);
                ctx.SaveChanges();
            }
            catch (System.Exception e)
            {

            }
        }
        public List<Products> searchproduct(string search)
        {
            var productoObtenido = (from o in ctx.Products where o.Nombre == search || o.Nombre.StartsWith(search) || search == null select o).ToList();
            return productoObtenido;
        }
        public List<Products> searchById(int id)
        {
            var producto = (from o in ctx.Products where o.Id == id select o).ToList();
            return producto;
        }
        public List<CatTypeProduct> getTypeProduct()
        {
            var type = (from o in ctx.CatTypeProduct select o).ToList();
            return type;
        }
        public List<CatBrands> getCatBrands()
        {
            var type = (from o in ctx.CatBrands select o).ToList();
            return type;
        }
        public List<CatCatalogs> getCatalogs()
        {
            var type = (from o in ctx.CatCatalogs select o).ToList();
            return type;
        }
        public List<CatColors> getCatColors()
        {
            var type = (from o in ctx.CatColors select o).ToList();
            return type;
        }
        public List<CatProviders> getCatProviders()
        {
            var type = (from o in ctx.CatProviders select o).ToList();
            return type;
        }
        public void DeleteImage(int idImage)
        {
            try
            {
                var image = (from o in ctx.ImagesProduct where o.IdImage == idImage select o).First();
                if (image != null)
                {
                    ctx.ImagesProduct.Remove(image);
                    ctx.SaveChanges();
                }
            }
            catch (System.Exception e)
            {

            }
        }
    }
}
