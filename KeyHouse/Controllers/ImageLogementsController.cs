using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KeyHouse.Models;

namespace KeyHouse.Controllers
{
    public class ImageLogementsController : Controller
    {
        private KeyHouseEntities db = new KeyHouseEntities();

        // GET: ImageLogements
        public ActionResult Index()
        {
            var imageLogement = db.ImageLogement.Include(i => i.Logements);
            
            return View(imageLogement.ToList());
        }

        // GET: ImageLogements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageLogement imageLogement = db.ImageLogement.Find(id);
            if (imageLogement == null)
            {
                return HttpNotFound();
            }
            return View(imageLogement);
        }

        // GET: ImageLogements/Create
        public ActionResult Create()
        {
            ViewBag.idLog = new SelectList(db.Logements, "idLogement", "TitreLogemenet");
            return View();
        }

        // POST: ImageLogements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idImage,NomImage,PathImage,idLog")] ImageLogement imageLogement)
        {
            if (ModelState.IsValid)
            {
                db.ImageLogement.Add(imageLogement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLog = new SelectList(db.Logements, "idLogement", "TitreLogemenet", imageLogement.idLog);
            return View(imageLogement);
        }

        // GET: ImageLogements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageLogement imageLogement = db.ImageLogement.Find(id);
            if (imageLogement == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLog = new SelectList(db.Logements, "idLogement", "TitreLogemenet", imageLogement.idLog);
            return View(imageLogement);
        }

        // POST: ImageLogements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idImage,NomImage,PathImage,idLog")] ImageLogement imageLogement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageLogement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLog = new SelectList(db.Logements, "idLogement", "TitreLogemenet", imageLogement.idLog);
            return View(imageLogement);
        }

        // GET: ImageLogements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageLogement imageLogement = db.ImageLogement.Find(id);
            if (imageLogement == null)
            {
                return HttpNotFound();
            }
            return View(imageLogement);
        }

        // POST: ImageLogements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageLogement imageLogement = db.ImageLogement.Find(id);
            db.ImageLogement.Remove(imageLogement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
