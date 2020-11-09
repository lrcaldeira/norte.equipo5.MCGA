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


        public ActionResult Index()
        {
            return View();
        }
    }
}