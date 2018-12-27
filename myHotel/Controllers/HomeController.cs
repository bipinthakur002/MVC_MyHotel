using myHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myHotel.Controllers
{
    public class HomeController : Controller
    {

        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        
        public ActionResult LoginCheck(string Email,string password)
        {
            if (ModelState.IsValid)
            {
                
                using (HotelContext _context = new HotelContext())
                {
                 
                    var obj = _context.customers.Where(a => a.Email.Equals(Email) && a.Password.Equals(password)).FirstOrDefault();
                    if (obj != null)
                    {
                        
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Name.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                    TempData["login"] = "profile Edited";
                }
            }
            return View("Login");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOff()
        {

            Session.Remove("UserName");
            Session.Remove("UserID");
            return View("Index");
            
        }

    }
}