using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationGuestBook.Data;
using WebApplicationGuestBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace WebApplicationGuestBook.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        private ApplicationDbContext _context;

        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        //index berisi daftar tamu
        public IActionResult Index(string Search, string TypeSearch)
        {
            //1. cek apakah Search ada atau tidak

            if (!string.IsNullOrEmpty(Search))
            {
                //1.1 kalo ada
                //1.2 periksa tipe search
                //1.2.1 jika Name
                if (TypeSearch == "Name")
                {
                    var guestlistsearch = _context.Guests.Where(g => g.Username == User.Identity.Name && g.Name.Contains(Search)).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }

                //1.2.2 Jika Address
                if (TypeSearch == "Address")
                {
                    var guestlistsearch = _context.Guests.Where(g => g.Address.Contains(Search) && g.Username == User.Identity.Name).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }

                //1.2.3 jika Phone
                if (TypeSearch == "Phone")
                {
                    var guestlistsearch = _context.Guests.Where(g => g.Phone.Contains(Search) && g.Username == User.Identity.Name).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }

                //1.2.4 jika Email
                if (TypeSearch == "Email")
                {
                    var guestlistsearch = _context.Guests.Where(g => g.Email.Contains(Search) && g.Username == User.Identity.Name).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }

                //1.2.5 jika Note
                if (TypeSearch == "Note")
                {
                    var guestlistsearch = _context.Guests.Where(g => g.Note.Contains(Search) && g.Username == User.Identity.Name).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }

                //1.2.6 jika Relation
                if (TypeSearch == "Relation")
                {
                    var guestlistsearch = _context.Guests.Where(g => g.Relation.Contains(Search) && g.Username == User.Identity.Name).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }

                //1.2.7 jika Nokendaraan
                else
                {
                    var guestlistsearch = _context.Guests.Where(g => g.NoKendaraan.Contains(Search) && g.Username == User.Identity.Name).ToList();

                    ViewBag.Guestlist = guestlistsearch;

                    return View();
                }
            }

            //1.3 kalo tidak ada, maka tampilkan seperti biasa


            //ambil data guest dari database
            var guestList = _context.Guests.Where(g => g.Username == User.Identity.Name).ToList();

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
            
            //kita validasi
            if (ModelState.IsValid)
            {
                
                //kita simpan ke database
                _context.Guests.Add(guest);

                _context.SaveChanges();

                return RedirectToAction("index");
            }

            var errorMessage = string.Join(" | ", ModelState.Values
                                           .SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage));
            ViewBag.errorMessage = errorMessage;

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
            //1. ambil data guest yang sekarang
            Guest guest_sekarang = _context.Guests.SingleOrDefault(g => g.Id == guest_baru.Id);

            //2. ambil data yang baru, yaitu guest_baru

            //3. ubah data yang sekarang sesuai dengan yang baru
            guest_sekarang.Name = guest_baru.Name;
            guest_sekarang.Address = guest_baru.Address;
            guest_sekarang.Email = guest_baru.Email;
            guest_sekarang.Note = guest_baru.Note;
            guest_sekarang.Phone = guest_baru.Phone;
            guest_sekarang.Relation = guest_baru.Relation;
            guest_sekarang.NoKendaraan = guest_baru.NoKendaraan;

            //4. simpan perubahan di database
            _context.SaveChanges();

            //5. balik ke halaman index dengan data yang terbaru
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGuest(int id) 
        {
        
            //1. pastikan data guest ada
            if (!_context.Guests.Any(g => g.Id == id))
            {
                //1.1 guest tidak ada, kembali ke index Listguest
                return RedirectToAction("Index");
            }

            //1.2 guest ada, hapus guest
            Guest guest = _context.Guests.SingleOrDefault(g => g.Id == id);
            _context.Guests.Remove(guest);

            //3. simpan perubahan
            _context.SaveChanges();

            //4. kembali ke index
            return RedirectToAction("Index");

        }

    }
}
