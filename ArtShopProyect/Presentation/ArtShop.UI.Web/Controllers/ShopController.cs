using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.UI.Process;

namespace ArtShop.UI.Web.Controllers
{
    public class ShopController : BaseController
    {
        // GET: Shop

        private ShopProcess shopprocess = new ShopProcess();

        [HttpPost]
        public ActionResult Add(int id)
        {
            this.CheckAuditPattern(id, true);
            var listModel = shopprocess.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                artistProcess.ArgregarArtista(artist);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
        public ActionResult Index()
        {
            var item = shopprocess.GetCartItem();
            return View(item);
        }
    }
}