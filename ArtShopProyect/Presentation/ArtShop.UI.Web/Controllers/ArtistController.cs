using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.UI.Process;

namespace ArtShop.UI.Web.Controllers
{
    public class ArtistController : Controller
    {
        private ArtistProcess artistProcess = new ArtistProcess();
        // GET: Artist
        public ActionResult Index()
        {
            var list = artistProcess.ListarTodosLosArtistas();
            return View(list);
        }
    }
}