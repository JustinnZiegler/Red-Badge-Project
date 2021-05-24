using Microsoft.AspNet.Identity;
using RedBadgeProject_Data;
using RedBadgeProject_Models;
using RedBadgeProject_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Red_Badge_Project.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        private ApplicationDbContext _service = new ApplicationDbContext();

        // GET: Genre
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GenreService(userId);
            var model = service.GetAllGenres();
            //List<Genre> genreList = _service.Genres.ToList();
            //List<Genre> orderedList = (List<Genre>)genreList.OrderBy(alpha => alpha.GenreName);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var _service = CreateGenreService();

            if (_service.CreateGenre(model))
            {
                TempData["SaveResult"] = "Your Genre was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Genre could not be created.");

            return View(model);
        }

        //public ActionResult GetSongsByGenre(int id)
        public ActionResult Details(int id)
        {
            var svc = CreateGenreService();
            var model = svc.GetAllSongsInGenre(id);

            return View(model);
        }

        public ActionResult GetByName(string name)
        {
            var svc = CreateGenreService();
            var model = svc.GetGenreByName(name);

            return View(model);
        }

        [ActionName("Update")]
        public ActionResult Update(int id)
        {
            var _service = CreateGenreService();
            var detail = _service.GetGenreById(id);
            var model =
                new GenreUpdate
                {
                    GenreId = detail.GenreId,
                    GenreName = detail.GenreName,
                };
            return View(model);
        }

        [HttpPost]
        [ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, GenreUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GenreId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var _service = CreateGenreService();

            if (_service.UpdateGenre(model))
            {
                TempData["SaveResult"] = "Your Genre was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Genre could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGenreService();
            var model = svc.GetGenreById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var _service = CreateGenreService();

            _service.DeleteGenre(id);

            TempData["SaveResult"] = "Your Genre was deleted.";

            return RedirectToAction("Index");
        }

        private GenreService CreateGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var _service = new GenreService(userId);
            return _service;
        }
    }
}