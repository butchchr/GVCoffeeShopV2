using GCCoffeeShopV2.Data;
using GCCoffeeShopV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCCoffeeShopV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CustomerSampleRead()
        {
            using (var context = new GCCoffeeShopContext())
            {
                var domainCustomer = context.Customers.First();

                return View(new CustomerModel
                {
                    Id = domainCustomer.Id,
                    FirstName = domainCustomer.FirstName,
                    // TODO other properties mapped here
                });
            }
        }

        public ActionResult CustomerSampleWrite(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new GCCoffeeShopContext())
                {
                    var domainCustomer = context.Customers.FirstOrDefault(c => c.Id == model.Id);
                    if (domainCustomer != null)
                    {
                        // not the ID - EF filled that in for you
                        domainCustomer.FirstName = model.FirstName;
                        // TODO: map the rest...

                        context.SaveChanges();
                        return View("Success");
                    }

                    return View("Not found");
                }
            }

            return View(model);
        }
    }
}