using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNV.Controllers
{
    public class NNVController : Controller
    {
        // GET: NNV
        public ActionResult NNV()
        {
            return View();

        }
        [ChildActionOnly]
        public ActionResult Tabela()
        {
            return PartialView("Tabela");
        }




    }



}