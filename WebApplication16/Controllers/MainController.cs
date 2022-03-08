using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication16.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Developers()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
       
        public ActionResult LOGOUT()
        {
            Session["SystemInfoForSession"] = null;
            return RedirectToAction("Login", "Account");
            return View();
        }
    }
}