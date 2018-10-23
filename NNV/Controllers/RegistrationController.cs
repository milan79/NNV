using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNV.Models;

namespace NNV.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration(int id=0)
        {
            Clanovi clan = new Clanovi();
            return View(clan);
        }

        [HttpPost]
        public ActionResult Registration (Clanovi clan)
        {
            using (NNVContext context = new NNVContext())
            {
                //ovo sam nesto probao preko operatora upita ali nisam istestirao da li radi;
                //var KorisnickoIme = from c in context.Clanovi
                //                    where c.KorisnickoIme == clan.KorisnickoIme
                //                    select c;
                //var Email = from c in context.Clanovi
                //            where c.Email == clan.Email
                //            select c;
                //if(KorisnickoIme!=null)
                //{
                //    ViewBag.DuplicateMessage = "Унето корисничко име је већ регистровано у бази, унесите ново.";
                //    return View("Registration", clan);
                //}
                //if(Email != null)
                //{
                //    ViewBag.SameMailMessage = "Унети E-mail је већ регистрован у бази, унесите нови.";
                //    return View("Registration", clan);
                //}
                //context.Clanovi.Add(clan);
                //context.SaveChanges();

                if (context.Clanovi.Any(x=>x.KorisnickoIme == clan.KorisnickoIme))
                {
                    ViewBag.DuplicateMessage = "Унето корисничко име је већ регистровано у бази, унесите ново.";
                    return View("Registration", clan);
                }
                if (context.Clanovi.Any(x => x.Email == clan.Email))
                {
                    ViewBag.SameMailMessage = "Унети E-mail је већ регистрован у бази, унесите нови.";
                    return View("Registration", clan);
                }
                context.Clanovi.Add(clan);
                context.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Успешна регистрација!";
            return View("Registration", new Clanovi());
        }
    }
}