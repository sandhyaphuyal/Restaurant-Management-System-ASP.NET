using System;
using WebApplication16.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Data.Entity;


namespace WebApplication16.Controllers
{

    public class MenuController : Controller
    {
        // GET: Menu
        MyProjectEntities db = new MyProjectEntities();
        public ActionResult Index()
        {
            var list = db.Table_food.ToList();
            return View(list);
        }
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(Table_food Table_food, HttpPostedFileBase UploadedFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UploadedFile != null)
                    {
                        string UploadedFilesPath = Server.MapPath("~/UploadedFiles");
                        string main_path = Path.Combine(UploadedFilesPath, UploadedFile.FileName);
                        UploadedFile.SaveAs(main_path);
                        Table_food.Image = "~/UploadedFiles" + "/" + UploadedFile.FileName;
                    }
                    db.Table_food.Add(Table_food);
                    db.SaveChanges();
                    FlashBag.setMessage(true, "Saved Successfully");
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Invalid Model");
                }
            }
            catch (Exception ex)
            {
                FlashBag.setMessage(false, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Table_food Table_menu = db.Table_food.Find(id);
            return View(Table_menu);
        }
        [HttpPost]
        public ActionResult Edit(Table_food Table_food, HttpPostedFileBase UploadedFile)
        {
            Table_food old_data = db.Table_food.Find(Table_food.MenuId);
            old_data.MenuName = Table_food.MenuName;
            old_data.price = Table_food.price;
            if (UploadedFile != null)
            {
                string UploadedFilesPath = Server.MapPath("~/UploadedFiles");
                string main_path = Path.Combine(UploadedFilesPath, UploadedFile.FileName);
                UploadedFile.SaveAs(main_path);
                Table_food.Image = "~/UploadedFiles" + "/" + UploadedFile.FileName;
            }
            old_data.Image = Table_food.Image;
            old_data.Status = Table_food.Status;
            db.Entry(old_data).State = EntityState.Modified;
            db.SaveChanges();
            FlashBag.setMessage(true, "Saved Successfully");
            //return View(Table_menu);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            Table_food Table_food = db.Table_food.Find(id);
            return View(Table_food);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int MenuId)
        {
            Table_food old_data = db.Table_food.Find(MenuId);
            db.Table_food.Remove(old_data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Aboutus()
        {
            return View();
        }

    }
}