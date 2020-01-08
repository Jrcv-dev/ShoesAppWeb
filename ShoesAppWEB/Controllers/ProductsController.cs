using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BussinesL;
using Entities;

namespace ShoesAppWEB.Controllers
{
    public class ProductsController : Controller
    {
        BussinesL.Bussines bussines = new BussinesL.Bussines();
        // GET: Products
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                //Hacer metodo para buscar por nombre
                return View(bussines.searchByName(search).ToList());
            }
            else if(searchBy == "ID")
            {
                int id = int.Parse(search);
                //hacer metodo para buscar por id
                return View(bussines.searchById(id));
            }
            else
            {
                return View(bussines.ObtenerProductos().ToList());
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ProductsEntity model)
        {
            bussines.GuardarProducto(model);
            return View("Index", bussines.ObtenerProductos());
        }
        public ActionResult Borrar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = bussines.ShowProduct(id);
            if(producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
        [HttpPost, ActionName("Borrar")]
        public ActionResult BorrarConfirmed(int id)
        {
            bussines.DeleteProduct(id);
            return View("Index", bussines.ObtenerProductos());
        }
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = bussines.ShowProduct(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = bussines.ShowProduct(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
        [HttpPost]
        public ActionResult Edit (int id, ProductsEntity model)
        {
            bussines.Edit(id, model);
            return View("Index", bussines.ObtenerProductos());
        }
        public ActionResult FileUpload(ProductsEntity pro, HttpPostedFileBase file, int id)
        {
            string pic = System.IO.Path.GetFileName(file.FileName);
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    bussines.AddImage(array, id); //id
                }
            }
            return RedirectToAction("Index");
        }
    }
}