using ExamenMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenMVC.Controllers
{
    public class CustomerController : Controller
    {
        private CodigoDB3Entities db = new CodigoDB3Entities();
        // GET: Costumer
        public ActionResult Index()
        {
            return View(db.Customers.Where(x=>x.IsActive==true).ToList());
        }

        // GET: Costumer/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Costumer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Costumer/Create
        [HttpPost]
        public ActionResult Create(Customers customers)
        {
            try
            {
                customers.IsActive = true;
                db.Customers.Add(customers);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Costumer/Edit/5
        public ActionResult Edit(int id)
        {
            Customers customers = db.Customers.Where(x=>x.CustomerID==id).FirstOrDefault();
            return View(customers);
        }

        // POST: Costumer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customers customers)
        {
            try
            {
                var customerModify = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                db.Entry(customerModify).State = EntityState.Modified;
                customerModify.Name = customers.Name;
                customerModify.DocumentNumber = customers.DocumentNumber;
                customerModify.DocumentType = customers.DocumentType;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Costumer/Delete/5
        public ActionResult Delete(int id)
        {
            Customers customers=db.Customers.Where(x => x.CustomerID==id).FirstOrDefault();
            return View(customers);
        }

        // POST: Costumer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customers customers)
        {
            try
            {
                var customersDelete = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                db.Entry(customersDelete).State = EntityState.Modified;
                customersDelete.IsActive = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult InactiveCustomers()
        {
            return View(db.Customers.Where(x => x.IsActive==false).ToList());
        }
    }
}
