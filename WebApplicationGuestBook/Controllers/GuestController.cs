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

        public IActionResult EditGuest(int id)
        {
            //ambil data guest berdasarkan id guest
            var guest = _context.Guests.SingleOrDefault(g => g.Id == id);

            //kirim data guest ke view melalui ViewBag.Guest
            ViewBag.Guest = guest;

            return View();
        }

        [HttpPost]
        public IActionResult EditGuest(Guest guest_baru)
        {
            //ambil data sesuai id yang ada di guest, kita namakan guest_sekarang
            Guest guest_sekarang = _context.Guests.SingleOrDefault(g => g.Id == guest_baru.Id);

            //data guest_sekarang akan diubah sesuai dengan guest_baru
            guest_sekarang.Name = guest_baru.Name;
            guest_sekarang.Address = guest_baru.Address;
            guest_sekarang.Email = guest_baru.Email;
            guest_sekarang.Note = guest_baru.Note;
            guest_sekarang.Phone = guest_baru.Phone;
            guest_sekarang.Relation = guest_baru.Relation;
            guest_sekarang.NoKendaraan = guest_baru.NoKendaraan;

            _context.SaveChanges();

            //arahkan user ke action index
            return RedirectToAction("Index");
            
        }

    }
}
