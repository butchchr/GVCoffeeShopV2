using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCCoffeeShopV2.Data;
using GCCoffeeShopV2.Domain.Models;
using GCCoffeeShopV2.Models;

namespace GCCoffeeShopV2.Controllers
{
    public class CustomerController : Controller
    {
        private GCCoffeeShopContext db = new GCCoffeeShopContext();

        public CustomerModel Map(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                FavoriteCoffee = customer.FavoriteCoffee,
                Email = customer.Email,
                Password = customer.Password
            };
        }

        public Customer Map(CustomerModel customer)
        {
            return new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth.Value,
                FavoriteCoffee = customer.FavoriteCoffee,
                Email = customer.Email,
                Password = customer.Password
            };
        }

        public void Map(CustomerModel model, Customer customer)
        {
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.DateOfBirth = model.DateOfBirth.Value;
            customer.FavoriteCoffee = model.FavoriteCoffee;
            customer.Email = model.Email;
            customer.Password = model.Password;

        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList().Select(x => Map(x)));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Map(customer));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(Map(model));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Map(customer));
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = db.Customers.FirstOrDefault(x => x.Id == model.Id);
                if (customer != null)
                {
                    Map(model, customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Map(customer));
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
