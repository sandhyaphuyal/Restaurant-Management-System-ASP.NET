using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Helper;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        MyProjectEntities db = new MyProjectEntities();
        [AllowAnonymousAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymousAttribute]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymousAttribute]
        [HttpPost]
        public ActionResult Login(Table_new Table_new )
        {
            try
            {
                var check_old_data = db.Table_new.Where(x => x.UserName == Table_new.UserName && x.Password == Table_new.Password).FirstOrDefault();
                if(check_old_data!=null)
                {
                    SystemInfoForSession sessionData = new SystemInfoForSession();
                    sessionData.UserId = check_old_data.UserId;
                    sessionData.UserName = check_old_data.UserName;
                    Session["SystemInfoForSession"] = sessionData;
                   
                    return RedirectToAction("MAIN", "templete");
                }
                else
                {
                    throw new Exception("Username or Password doesn't match.");
                    
                }

            }
            catch(Exception ex)
            {
                FlashBag.setMessage(false, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            return View();
           
        }
        public ActionResult LogOut()
        {
            Session["SystemInfoForSession"] = null;
            return RedirectToAction("Login", "Account");
        }
        
    }
}