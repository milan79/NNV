using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NNV.Models;
using System.Data.SqlClient;
using System.Data.Sql;

namespace NNV.Controllers
{
    public class ClanoviController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: Clanovi
        public ActionResult Index()
        {
            return View(db.Clanovi.ToList());
        }

        public ActionResult IndexAdmin()
        {
            return View(db.Clanovi.ToList());
        }
        public ActionResult AdminPageView()
        {
            return View(db.Clanovi.ToList());
        }
        // GET: Clanovi/Details/5

        [ChildActionOnly]
            public ActionResult Tabela()
        {
            return PartialView("Tabela", db.Clanovi.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanovi clanovi = db.Clanovi.Find(id);
            if (clanovi == null)
            {
                return HttpNotFound();
            }
            return View(clanovi);
        }

        // GET: Clanovi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clanovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClanID,ImePrezime,Email,Status,KorisnickoIme,Lozinka")] Clanovi clanovi)
        {
            if (ModelState.IsValid)
            {
                db.Clanovi.Add(clanovi);
                db.SaveChanges();
                return RedirectToAction("AdminPageView");
            }

            return View(clanovi);
        }

        // GET: Clanovi/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Clanovi clanovi = db.Clanovi.Find(id);
                if (clanovi == null)
                {
                    return HttpNotFound();
                }
                return View(clanovi);
            }
            catch (SqlException se)
            {
                ViewBag.DuplicateMessage = "Унето корисничко име / e-mail је већ регистровано у бази, унесите ново.";
                return View("Edit");
            }
            catch (Exception Stana)
            {
                ViewBag.SQLMessage = Stana.Message.ToString();
                return View("Edit");
            }
        }

        // POST: Clanovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClanID,ImePrezime,Email,Status,KorisnickoIme,Lozinka")] Clanovi clanovi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(clanovi).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AdminPageView");
                }
                return View(clanovi);
            }
            catch (SqlException se)
            {
                ViewBag.DuplicateMessage = "Унето корисничко име / e-mail је већ регистровано у бази, унесите ново.";
                return View("Edit");
            }
            catch (Exception ex)
            {
                ViewBag.SQLMessage = ex.Message.ToString();
                return View("Edit");
            }

        }

        // GET: Clanovi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanovi clanovi = db.Clanovi.Find(id);
            if (clanovi == null)
            {
                return HttpNotFound();
            }
            return View(clanovi);
        }

        // POST: Clanovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clanovi clanovi = db.Clanovi.Find(id);
            db.Clanovi.Remove(clanovi);
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
