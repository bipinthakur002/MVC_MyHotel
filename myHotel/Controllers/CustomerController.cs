using myHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotmyHotelel.Controllers
{
    public class CustomerController : Controller
    {
        private HotelContext _context;
        public CustomerController()
        {
            _context = new HotelContext();
        }

        public ActionResult New()
        {
            Customer customer = new Customer();

            return View(customer);
        }

        public ActionResult Save(Customer cust)
        {
           
            if (!ModelState.IsValid)
            {
                Customer customer = new Customer();
                return View("New", customer);
            }
            if (cust.Id == 0)
            {
                _context.customers.Add(cust);
               

            }
           
            else
            {


                var customerId = _context.customers.Single(c => c.Id == cust.Id);
                customerId.Name = cust.Name;
                customerId.Mobile = cust.Mobile;
                customerId.Address = cust.Address;
                customerId.Adhar = cust.Adhar;
                customerId.Email = cust.Email;
                customerId.Password = cust.Password;
                TempData["rid"] = "profile Edited";
                _context.SaveChanges();


                return RedirectToAction("Edit");

            }
            TempData["rid"]="Form Submitted";
            _context.SaveChanges();
            

            return RedirectToAction("New");
        }

        public ActionResult Edit()
        {
            int id = Int32.Parse(Session["UserID"].ToString());
            

            var cust = _context.customers.SingleOrDefault(c => c.Id == id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            Customer customerr = new Customer();
            customerr = cust;
            return View("New", customerr);
        }


        public JsonResult IsEmailAvailable(string Email)
        {
            if(Session["UserId"]!=null)
            {
                return Json(_context.customers.Any(c => c.Email == Email), JsonRequestBehavior.AllowGet);
            }


            return Json(!_context.customers.Any(c => c.Email == Email),JsonRequestBehavior.AllowGet);
        }


       
    }

}  



 