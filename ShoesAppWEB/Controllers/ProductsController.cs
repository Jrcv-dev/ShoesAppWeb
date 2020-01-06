using System;
using System.Collections.Generic;
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
        // GET: Products
        public ActionResult Index()
        {
            var bussines = new BussinesL.Bussines();
            return View(bussines.ObtenerProductos());
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ProductsEntity model)
        {
            var bussines = new BussinesL.Bussines();
            bussines.GuardarProducto(model);
            return View("Index");
        }
        public ActionResult Borrar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bussines = new BussinesL.Bussines();
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
            var bussines = new BussinesL.Bussines();
            bussines.DeleteProduct(id);
            return View("Index");
        }
    }
}