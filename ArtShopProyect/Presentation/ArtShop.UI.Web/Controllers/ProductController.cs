using System;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using System.Net;

namespace ArtShop.UI.Web.Controllers
{
    public class ProductController : BaseController
    {
        private ProductProcess productProcess = new ProductProcess();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult AddProduct(Product product)
        {
            product.SetArtistId(product.art);
            var list = productProcess.AgregarProducto(product);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public void DeleteProduct(int id)
        {
            productProcess.BorrarProducto(id);
        }

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult EditProduct(Product product)
        {
            product.SetArtistId(product.art);
            var prod = productProcess.EditarProducto(product);
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts()
        {
            var list = new ProductProcess().ListarTodosLosProductos();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProduct(int Id)
        {
            var prod = productProcess.BuscarProductoPorId(Id);
            prod.art = prod.Artist.Id;
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
    }
}