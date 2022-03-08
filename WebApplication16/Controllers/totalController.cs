using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class totalController : Controller
    {
        // GET: total
        MyProjectEntities db = new MyProjectEntities();
        public ActionResult Index()
        {
            var list = db.Table_cus.ToList();
            return View("Index", list);
        }
        private void CommonDropDown(Table_cus Table_cus)
        {
            ViewBag.menuList = new SelectList(db.Table_food.Where(x => x.Status == true).ToList(), "MenuId", "MenuName");

        }
        public ActionResult Add()
        {
            var new_obj = new Table_cus();
            CommonDropDown(new_obj);
            return View();
        }
        [HttpPost]
        public ActionResult Add(Table_cus Table_cus)
        {
            db.Table_cus.Add(Table_cus);
            db.SaveChanges();
            ViewBag.message = "saved successfully";
            CommonDropDown(Table_cus);
            return RedirectToAction("Index");
        }

        public JsonResult GetPriceByItemId(int id)
        {
            var data = db.Table_food.Find(id);
            return Json(data.price, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Delete(int id)
        {
            Table_cus Table_cus = db.Table_cus.Find(id);
            return View(Table_cus);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int CID)
        {
            Table_cus old_data = db.Table_cus.Find(CID);
            db.Table_cus.Remove(old_data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        }
    }

        

