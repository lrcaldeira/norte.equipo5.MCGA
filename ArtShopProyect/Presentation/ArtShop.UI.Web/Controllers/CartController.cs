using System;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using System.Net;

namespace ArtShop.UI.Web.Controllers
{
    public class CartController : BaseController
    {
        private CartProcess cartProcess = new CartProcess();

        // GET: Cart
        public ActionResult Index()
        {
            var list = cartProcess.SelectList();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            this.CheckAuditPattern(cart, true);
            var listModel = cartProcess.ValidateModel(cart);
            if (ModelIsValid(listModel))
                return View(cart);
            try
            {
                cartProcess.ArgregarCarrito(cart);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.MessageDanger = ex.Message;
                return View(cart);
            }
        }
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = cartProcess.GetCart(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var artist = cartProcess.GetCart(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            cartProcess.BorrarCarrito(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = cartProcess.GetCart((int)id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }
    }
}