﻿using System;
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
            var productoObtenido = (from o in ctx.Products where o.Nombre == search || o.Nombre.StartsWith(search) || search== null select o).ToList();
            return productoObtenido;
        }
        public List<Products> searchById(int id)
        {
            var producto = (from o in ctx.Products where o.Id == id select o).ToList();
            return producto;
        }
        /* public void DeleteImage(Products producto)
         {
             try
             {
                 ctx.ImagesProduct.RemoveRange(producto.ImagesProduct);
                 ctx.SaveChanges();
             }catch(System.Exception e)
             {

             }
         }*/
    }
}
