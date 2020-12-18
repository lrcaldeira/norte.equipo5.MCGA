﻿using System;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using System.Net;

namespace ArtShop.UI.Web.Controllers
{
    public class ProductController : BaseController
    {
        private ProductProcess productProcess = new ProductProcess();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            this.CheckAuditPattern(product, true);
            var listModel = productProcess.ValidateModel(product);
            if (ModelIsValid(listModel))
                return View(product);
            try
            {
                productProcess.AgregarProducto(product);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }
        }

        public JsonResult AddProduct(Product product)
        {
            product.SetArtistId(product.art);
            var ap = new ProductProcess();
            var list = ap.AgregarProducto(product);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productProcess.GetProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = productProcess.GetProduct(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            productProcess.BorrarProducto(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productProcess.GetProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public JsonResult GetProducts()
        {
            var list = new ProductProcess().ListarTodosLosProductos();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            this.CheckAuditPattern(product);
            var listModel = productProcess.ValidateModel(product);
            if (ModelIsValid(listModel))
                return View(product);
            try
            {
                productProcess.EditarProducto(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }
        }

    }
}