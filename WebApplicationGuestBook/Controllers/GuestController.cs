using Microsoft.AspNetCore.Mvc;
using WebApplicationGuestBook.Data;
using WebApplicationGuestBook.Models;

namespace WebApplicationGuestBook.Controllers
{
    public class GuestController : Controller
    {
        private ApplicationDbContext _context;

        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        //index berisi daftar tamu
        public IActionResult Index()
        {
            //ambil data guest dari database
            var guestList = _context.Guests.ToList();

            ViewBag.GuestList = guestList;

            return View();
        }

        public IActionResult AddGuest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            //kita apakan data itu

            //kita validasi

            if (ModelState.IsValid)
            {
                //kita simpan ke database
                _context.Guests.Add(guest);

                _context.SaveChanges();

                return RedirectToAction("index");
            }

            //kasi peringatan di bawah


            // ada yang tidak valid kirim pesan error ke user

            return View();
        }

    }
}
