using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class FoodController : Controller
    {


        // GET: Food


        MyProjectEntities DdModel = new MyProjectEntities();

        public ActionResult Index()
        {
            return View(DdModel.Table_1.ToList());

        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(DdModel.Table_1.Where(x => x.Foodid == id).FirstOrDefault());

        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            /* List <SelectListItem> items = new List<SelectListItem>();
              SelectListItem item1 = new SelectListItem() { Text = "KIST", Value = "1", Selected = true };
              SelectListItem item2 = new SelectListItem() { Text = "NIST", Value = "2", Selected = false };
              SelectListItem item3 = new SelectListItem() { Text = "KATHMANDU", Value = "3", Selected = false };
              items.Add(item1);
              items.Add(item2);
              if (value != null)
              {
                  items.Where(i => i.Value == value.ToString()).First().Selected = true;

              }
              items.Add(item3);*/
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Table_1 table_1, HttpPostedFileBase UploadedFile)
        {
            /* if (UploadedFile != null)
             {
                 string uploadedfilespath = Server.MapPath("~/uploadedfiles");
                 string main_path = Path.Combine(UploadedFilesPath, UploadedFile.FileName);
                 UploadedFile.SaveAs(main_path);
                 Customer.Image = "~/UploadedFiles" + UploadedFile.FileName;

             }*/
            try
            {
                if (ModelState.IsValid)
                {
                    if (UploadedFile != null)
                    {
                        string uploadedfilespath = Server.MapPath("~/uploadedfiles");
                       /// string main_path = Path.Combine(UploadedFilesPath, UploadedFile.FileName);
                      //  UploadedFile.SaveAs(main_path);
                      //  Table_1.Image = "~/UploadedFiles" + "/" + UploadedFile.FileName;

                    }


                    DdModel.Table_1.Add(table_1);
                    DdModel.SaveChanges();
                    FlashBag.setMessage(true, "saved successfully");

                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("invalid message");

                }
            }
            catch (Exception ex)
            {
                FlashBag.setMessage(false, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            return View();
        }
    

        // GET: Customer/Edit/5
        public ActionResult Edit(int id )
        {
            return View(DdModel.Table_1.Where(x => x.Foodid == id).FirstOrDefault());

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Table_1 table_1, HttpPostedFileBase UploadedFile)
        {
            try
            {
                // TODO: Add update logic here
                DdModel.Entry(table_1).State = EntityState.Modified;
                DdModel.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(DdModel.Table_1.Find(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                Table_1 table_1 = DdModel.Table_1.Find(id);
                DdModel.Table_1.Remove(table_1);
                DdModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult back()
        {
            return View();
        }

    }
}