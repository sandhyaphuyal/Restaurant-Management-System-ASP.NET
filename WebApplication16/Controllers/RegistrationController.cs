using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
    
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        // GET: Registration
        MyProjectEntities db = new MyProjectEntities();
        public ActionResult Index()
        {
            var list = db.Table_new.ToList();
            return View(list);
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Table_new Table_New)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    //throw new exception("Test FlashBag");
                    db.Table_new.Add(Table_New);
                    db.SaveChanges();
                    FlashBag.setMessage(true, "saved successfully");
                    
                    return RedirectToAction("SignUp", "Registration");
                }
                
                      else
                    {
                        throw new Exception("Model State is Invalid. ");
                    }
                
            }
            catch(Exception ex)
            {
                FlashBag.setMessage(false, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            return View(Table_New);
        }
    }
}