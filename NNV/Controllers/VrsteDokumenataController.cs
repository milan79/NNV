using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NNV.Models;

namespace NNV.Controllers
{
    public class VrsteDokumenataController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: VrsteDokumenata
        public ActionResult Index()
        {
            return View(db.VrsteDokumenata.ToList());
        }

        // GET: VrsteDokumenata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrsteDokumenata vrsteDokumenata = db.VrsteDokumenata.Find(id);
            if (vrsteDokumenata == null)
            {
                return HttpNotFound();
            }
            return View(vrsteDokumenata);
        }

        // GET: VrsteDokumenata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VrsteDokumenata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DokumentID,VrstaDokumenta")] VrsteDokumenata vrsteDokumenata)
        {
            if (ModelState.IsValid)
            {
                db.VrsteDokumenata.Add(vrsteDokumenata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrsteDokumenata);
        }

        // GET: VrsteDokumenata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrsteDokumenata vrsteDokumenata = db.VrsteDokumenata.Find(id);
            if (vrsteDokumenata == null)
            {
                return HttpNotFound();
            }
            return View(vrsteDokumenata);
        }

        // POST: VrsteDokumenata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DokumentID,VrstaDokumenta")] VrsteDokumenata vrsteDokumenata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrsteDokumenata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrsteDokumenata);
        }

        // GET: VrsteDokumenata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrsteDokumenata vrsteDokumenata = db.VrsteDokumenata.Find(id);
            if (vrsteDokumenata == null)
            {
                return HttpNotFound();
            }
            return View(vrsteDokumenata);
        }

        // POST: VrsteDokumenata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VrsteDokumenata vrsteDokumenata = db.VrsteDokumenata.Find(id);
            db.VrsteDokumenata.Remove(vrsteDokumenata);
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
