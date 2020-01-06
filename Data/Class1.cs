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
                var registro = (from o in ctx.Products where o.Id == id select o).First();
                if (registro != null)
                {
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
    }
}
