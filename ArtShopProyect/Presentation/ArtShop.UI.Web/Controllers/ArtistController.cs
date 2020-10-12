using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using System.Net;

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


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            artist.ChangedOn = DateTime.Now;
            artist.CreatedOn = DateTime.Now;
            artistProcess.ArgregarArtista(artist);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = artistProcess.GetArtist(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var artist = artistProcess.GetArtist(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            artistProcess.BorrarArtista(id);
            return RedirectToAction("Index");
        }

    }
}