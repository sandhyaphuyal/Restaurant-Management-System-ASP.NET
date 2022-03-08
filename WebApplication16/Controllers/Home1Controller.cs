using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sub.Repositories;
using WebApplication16.Models;

namespace sub.Controllers
{
    public class Home1Controller : Controller
    {
        private MyProjectEntities objRestaurantDBEntities;
        public Home1Controller()
        {
            objRestaurantDBEntities = new MyProjectEntities();
        }
        // GET: Home1
        public ActionResult Index()
        {
            CustomerRepository objcustomerRepository = new CustomerRepository();
            ItemRepository objitemRepository = new ItemRepository();
            PaymentTypeRepository objpaymentTypeRepository = new PaymentTypeRepository();
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(objcustomerRepository.GetAllCustomers(), objitemRepository.GetAllItems(), objpaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        private JsonResult Json(decimal unitPrice, JsonRequestBehavior jsonRequestBehavior, object allowGet)
        {
            throw new NotImplementedException();
        }
    }
}
