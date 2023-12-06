using EvidentaMasini.Data;
using EvidentaMasini.Models;
using EvidentaMasini.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace EvidentaMasini.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? page)
        {
            return View(_db.cars?.Include(c=>c.combustion));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //GET car detail acation method
        public ActionResult Detail(string? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var car = _db.cars?.Include(c => c.combustion).FirstOrDefault(c => c.vin == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        //POST car detail acation method
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(string? id)
        {
            List<Car> cars = new List<Car>();
            if (id == null)
            {
                return NotFound();
            }

            var car = _db.cars?.Include(c => c.combustion).FirstOrDefault(c => c.vin == id);
            if (car == null)
            {
                return NotFound();
            }

            cars = HttpContext.Session.Get<List<Car>>("car");
            if (cars == null)
            {
                cars = new List<Car>();
            }
            cars.Add(car);
            HttpContext.Session.Set("car", cars);
            return RedirectToAction(nameof(Index));
        }       

    }
}
