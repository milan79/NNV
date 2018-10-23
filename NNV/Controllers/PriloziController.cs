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
    public class PriloziController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: Prilozi
        public ActionResult Index()
        {
            var prilozi = db.Prilozi.Include(p => p.Sednice);
            return View(prilozi.ToList());
        }
        

        public ActionResult IndexAdmin()
        {
            var prilozi = db.Prilozi.Include(p => p.Sednice);
            return View(prilozi.ToList());
        }
        public ActionResult AdminPageView()
        {
            return View(db.Prilozi.ToList());
        }
        // GET: Prilozi/Details/5

        //SednicaID = item.SednicaID, PrilogID = item.PrilogID
        public ActionResult Details(int? SednicaID, int? PrilogID)
        {
            if (SednicaID == null || PrilogID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prilozi prilozi = db.Prilozi.Find(SednicaID, PrilogID);
            if (prilozi == null)
            {
                return HttpNotFound();
            }
            return View(prilozi);
        }

        // GET: Prilozi/Create
        public ActionResult Create()
        {
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "VrstaSednice");
            return View();
        }

        // POST: Prilozi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SednicaID,PrilogID,DokumentID,Putanja,Poslato,DatumSlanja")] Prilozi prilozi)
        {
            if (ModelState.IsValid)
            {
                db.Prilozi.Add(prilozi);
                db.SaveChanges();
                return RedirectToAction("AdminPageView");
            }

            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "VrstaSednice", prilozi.SednicaID);
            return View(prilozi);
        }

        // GET: Prilozi/Edit/5
        public ActionResult Edit(int? SednicaID, int? PrilogID)
        {
            if (SednicaID == null || PrilogID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prilozi prilozi = db.Prilozi.Find(SednicaID, PrilogID);
            if (prilozi == null)
            {
                return HttpNotFound();
            }
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "VrstaSednice", prilozi.SednicaID);
            return View(prilozi);
        }

        // POST: Prilozi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SednicaID,PrilogID,DokumentID,Putanja,Poslato,DatumSlanja")] Prilozi prilozi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prilozi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminPageView");
            }
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "SednicaID", prilozi.SednicaID);
            return View(prilozi);
        }

        // GET: Prilozi/Delete/5
        public ActionResult Delete(int? SednicaID, int? PrilogID)
        {
            if (SednicaID == null || PrilogID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prilozi prilozi = db.Prilozi.Find(SednicaID, PrilogID);
            if (prilozi == null)
            {
                return HttpNotFound();
            }
            return View(prilozi);
        }

        // POST: Prilozi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int SednicaID, int PrilogID)
        {
            Prilozi prilozi = db.Prilozi.Find(SednicaID, PrilogID);
            db.Prilozi.Remove(prilozi);
            db.SaveChanges();
            return RedirectToAction("AdminPageView");
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
