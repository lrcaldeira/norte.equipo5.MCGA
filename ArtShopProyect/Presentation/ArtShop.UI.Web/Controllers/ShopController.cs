using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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