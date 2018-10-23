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
    public class PrisustvoController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: Prisustvo
        public ActionResult Index()
        {
            var prisustvoes = db.Prisustvoes.Include(p => p.Clanovi).Include(p => p.Sednice);
            return View(prisustvoes.ToList());
        }
        //SednicaID = item.SednicaID, ClanID = item.ClanID
        // GET: Prisustvo/Details/5
        public ActionResult Details(int? SednicaID, int? ClanID)
        {
            if (SednicaID == null || ClanID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisustvo prisustvo = db.Prisustvoes.Find(SednicaID, ClanID);
            if (prisustvo == null)
            {
                return HttpNotFound();
            }
            return View(prisustvo);
        }

        // GET: Prisustvo/Create
        public ActionResult Create()
        {
            ViewBag.ClanID = new SelectList(db.Clanovi, "ClanID", "ClanID");
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "SednicaID");
            return View();
        }

        // POST: Prisustvo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SednicaID,ClanID,Prisutan,Opravdano")] Prisustvo prisustvo)
        {
            if (ModelState.IsValid)
            {
                db.Prisustvoes.Add(prisustvo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClanID = new SelectList(db.Clanovi, "ClanID", "ClanID", prisustvo.ClanID);
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "SednicaID", prisustvo.SednicaID);
            return View(prisustvo);
        }

        // GET: Prisustvo/Edit/5
        public ActionResult Edit(int? SednicaID, int? ClanID)
        {
            if (SednicaID == null || ClanID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisustvo prisustvo = db.Prisustvoes.Find(SednicaID, ClanID);
            if (prisustvo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClanID = new SelectList(db.Clanovi, "ClanID", "ClanID", prisustvo.ClanID);
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "SednicaID", prisustvo.SednicaID);
            return View(prisustvo);
        }

        // POST: Prisustvo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SednicaID,ClanID,Prisutan,Opravdano")] Prisustvo prisustvo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prisustvo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClanID = new SelectList(db.Clanovi, "ClanID", "ClanID", prisustvo.ClanID);
            ViewBag.SednicaID = new SelectList(db.Sednice, "SednicaID", "SednicaID", prisustvo.SednicaID);
            return View(prisustvo);
        }

        // GET: Prisustvo/Delete/5
        public ActionResult Delete(int? SednicaID, int? ClanID)
        {
            if (SednicaID == null || ClanID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisustvo prisustvo = db.Prisustvoes.Find(SednicaID, ClanID);
            if (prisustvo == null)
            {
                return HttpNotFound();
            }
            return View(prisustvo);
        }

        // POST: Prisustvo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int SednicaID, int ClanID)
        {
            Prisustvo prisustvo = db.Prisustvoes.Find(SednicaID, ClanID);
            db.Prisustvoes.Remove(prisustvo);
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
