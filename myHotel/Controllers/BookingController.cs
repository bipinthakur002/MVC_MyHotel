using myHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace myHotel.Controllers
{
    public class BookingController : Controller
    {
        private HotelContext _context;
        public BookingController()
        {
            _context = new HotelContext();
        }
        public ActionResult Index()
        {
            if (Session["UserName"] != null && Session["UserName"].ToString() == "Admin")
            {
                var buk = _context.bookings.ToList();
                return View(buk);
            }
            // int numVal = Int32.Parse("-105");
            if (Session["UserName"] != null)
            {
                var idd = Int32.Parse(Session["UserID"].ToString());

                var book = _context.bookings.Where(b => b.CustomerId == idd).ToList();
                return View(book);
                

            }
            return HttpNotFound();
        }

        public ActionResult New(int id)
        {
            Booking book = new Booking();
            TempData["rid"] = id;
            
            
            return View(book);
        }


       


        public ActionResult Save(Booking booking)
        {
            Console.WriteLine(booking.Id);
            if (!ModelState.IsValid)
            {
                Booking book = new Booking();
                return View("New", book);
            }
            else if (booking.Id == 0)
            {
                var room = _context.rooms.Single(r => r.Id == booking.RoomId);
                if (room.ToalAvailable < 1)
                {
                    return View("Index", "Room");
                }

                room.ToalAvailable--;
                booking.RoomNo = room.ToalAvailable + 100;
                    booking.BookingDate= DateTime.Today;
                _context.bookings.Add(booking);
            }
            else
            {
                

                var bookId = _context.bookings.Single(c => c.Id == booking.Id);
                bookId.CheckIn = booking.CheckIn;
                bookId.CheckOut = booking.CheckOut;
                bookId.CustomerId = booking.CustomerId;
                    bookId.RoomId = booking.RoomId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Room");
        }

        public ActionResult Edit(int id)
        {

            var book = _context.bookings.SingleOrDefault(b => b.Id == id);
            TempData["rid"] = book.RoomId;

            if (book == null)

            {
                return HttpNotFound();
            }

            Booking books = new Booking();
            books = book;
            return View("New", books);
        }


        public ActionResult Delete(int id)
        {
            Booking booking = _context.bookings.Single(b => b.Id == id);
            var room = _context.rooms.Single(r => r.Id == booking.RoomId);
            var buk = _context.bookings.SingleOrDefault(b => b.Id == id);

            if (buk == null)

            {
                return HttpNotFound();
            }
            
            _context.bookings.Remove(buk);
            room.ToalAvailable++;
            _context.SaveChanges();

            var idd = Int32.Parse(Session["UserID"].ToString());

            var book = _context.bookings.Where(b => b.CustomerId == idd).ToList();

            return View("Index",book);

        }


        public ActionResult Search()
        {
            Booking book = new Booking();
            return View();
        }
        public ActionResult SearchResult(Booking booking)
        {
            var from = booking.CheckIn;
            var to = booking.CheckOut;

            Console.WriteLine(from);


            var obj = _context.bookings.Where(a => DbFunctions.TruncateTime(a.CheckIn) < DbFunctions.TruncateTime(booking.CheckIn) && DbFunctions.TruncateTime(a.CheckOut) > DbFunctions.TruncateTime(booking.CheckOut)).ToList();

            return View("Index",obj);
        }


        public ActionResult Today()
        {
            var today = DateTime.Now;
            var obj = _context.bookings.Where(a => DbFunctions.TruncateTime(a.BookingDate) == today.Date).ToList();
            return View("Index",obj);

        }
    }


}