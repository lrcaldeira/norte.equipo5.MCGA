using System;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using System.Net;

namespace ArtShop.UI.Web.Controllers
{
    public class ArtistController : BaseController
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
            return View(new Artist());
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var listModel = artistProcess.ValidateModel(artist);
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

        public ActionResult Edit(int? id)
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

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            this.CheckAuditPattern(artist);
            var listModel = artistProcess.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                artistProcess.EditarArtista(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }

    }
}