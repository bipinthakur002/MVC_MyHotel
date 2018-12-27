using myHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myHotel.Controllers
{
    public class RoomController : Controller
    {
        private HotelContext _context;
        public RoomController()
        {
            _context = new HotelContext();
        }




        public ActionResult Index()
        {
            Room room = new Room();
            return View(room);
        }




        [Filter.AutorizeUser]

        public ActionResult New()
        {
            Room room = new Room();
            return View(room);
        }




        [Filter.AuthorizeAdmin]
        public ActionResult Save(Room room)
        {
            if (!ModelState.IsValid)
            {
                Room rooms = new Room();
                return View("New", rooms);
            }
            else if (room.Id == 0)
            {
                room.ToalAvailable = room.TotalRoom;
                _context.rooms.Add(room);
            }
            else
            {


                var rooomId = _context.rooms.Single(c => c.Id == room.Id);
                rooomId.Capacity = room.Capacity;
                rooomId.Price = room.Price;
                rooomId.TotalRoom = room.TotalRoom;
                
                rooomId.Roomtype = room.Roomtype;



            }
            _context.SaveChanges();

            TempData["room"] = "Done";





            return RedirectToAction("New", "Room");
        }




        [Filter.AuthorizeAdmin]
        public ActionResult Edit(int id)
        {
            var rom = _context.rooms.SingleOrDefault(r => r.Id == id);

            if (rom == null)

            {
                return HttpNotFound();
            }

            Room room = new Room();
            room = rom;
            return View("New", room);
        }



        [Filter.AuthorizeAdmin]
        public ActionResult Delete(int id)
        {
            var rom = _context.rooms.SingleOrDefault(r => r.Id == id);

            if (rom == null)

            {
                return HttpNotFound();
            }
            _context.rooms.Remove(rom);
            _context.SaveChanges();
            return View("Index");

        }


        
        public ActionResult Detail(Room room)
        {
            
            var rorom = _context.rooms.Where(r => r.Roomtype==(room.Roomtype)).ToList();

            return View(rorom);
            
        }

        public ActionResult Detaill()
        {

            var rorom = _context.rooms.ToList();

            return View("Detail",rorom);

        }

        
        //public JsonResult IsRoomTypeAvailable(RoomType Roomtype)
        //{
        //    var name = Session["UserName"];

        //    if (Session["UserID"] != null && name.ToString()!="Admin")
        //    {
        //        return Json(_context.rooms.Any(r => r.Roomtype == Roomtype), JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(!_context.rooms.Any(r => r.Roomtype==Roomtype), JsonRequestBehavior.AllowGet);
        //}

    }
}