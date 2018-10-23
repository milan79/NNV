using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNV.Models;

namespace NNV.Controllers
{
    public class LoginController : Controller
    {
        //NNVContext context = new NNVContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autorizacija (Clanovi userModel)
        {
            using (NNVContext context = new NNVContext())
            {
                //var userDetails = context.Clanovi.Where(x => x.KorisnickoIme == userModel.KorisnickoIme && x.Lozinka == userModel.Lozinka && x.admin == false).FirstOrDefault();
                //var userAdmin = context.Clanovi.Where(x => x.KorisnickoIme == userModel.KorisnickoIme && x.Lozinka == userModel.Lozinka && x.admin == true).FirstOrDefault();

                var userDetails = (from c in context.Clanovi
                                   where (c.KorisnickoIme == userModel.KorisnickoIme && c.Lozinka == userModel.Lozinka && c.admin == false)
                                   select c).FirstOrDefault();
                var userAdmin = (from c in context.Clanovi
                                 where (c.KorisnickoIme == userModel.KorisnickoIme && c.Lozinka == userModel.Lozinka && c.admin == true)
                                 select c).FirstOrDefault();
                                   

                if (userDetails == null && userAdmin == null)
                {
                    //userModel.LoginErrorMessage = "Погрешно корисничко име или лозинка.";
                    if (userModel.KorisnickoIme != null || userModel.Lozinka != null)
                        ViewBag.Message = string.Format("Погрешно корисничко име или лозинка.");
                    return View("Index", userModel);
                }
                else
                {
                    if(userAdmin!=null)
                        return RedirectToAction("Index", "Admin");                   
                    //Session["ClanID"] = userDetails.ClanID;
                    Session["KorisnickoIme"] = userDetails.KorisnickoIme;
                    return RedirectToAction("Index", "Promena");
                }
            }
        }

        public ActionResult Logout()
        {
            //int userID = (int)Session["ClanID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}