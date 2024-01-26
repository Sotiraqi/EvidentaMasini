using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidentaMasini.Data;
using EvidentaMasini.Models;

namespace EvidentaMasini.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        
        private readonly ApplicationDbContext _db;


        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() => View(_db.cars?.Include(c => c.combustion).ToList());
                

        //Get Create method
        public IActionResult Create()
        {
            ViewData["carCombustionId"] = new SelectList(_db.combustionTypes?.ToList(), "combustionId", "combustion");
            return View();
        }


        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)            
            {
                var searchProduct = _db.cars?.FirstOrDefault(c => c.vin == car.vin);
                if (searchProduct != null)
                {
                    ViewBag.message = "This car already exist";
                    ViewData["carCombustionId"] = new SelectList(_db.combustionTypes?.ToList(), "combustionId", "combustion");
                    return View(car);
                }
                
                _db.cars?.Add(car);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        //GET Edit Action Method

        public ActionResult Edit(string? vin)
        {
            ViewData["carCombustionId"] = new SelectList(_db.combustionTypes?.ToList(), "combustionId", "combustion");
            if (vin == null)
            {
                return NotFound();
            }

            var product = _db.cars?.Include(c => c.combustion).FirstOrDefault(c => c.vin == vin);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Edit Action Method
        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.cars?.Update(car);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        //GET Details Action Method
        public ActionResult Details(string? vin)
        {

            if (vin == null)
            {
                return NotFound();
            }

            var car = _db.cars?.Include(c => c.combustion).FirstOrDefault(c => c.vin == vin);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        //GET Delete Action Method

        public ActionResult Delete(string? vin)
        {
            if (vin == null)
            {
                return NotFound();
            }

            var car = _db.cars?.Include(c => c.combustion).Where(c => c.vin == vin).FirstOrDefault();
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        //POST Delete Action Method

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string? vin)
        {
            if (vin == null)
            {
                return NotFound();
            }

            var car = _db.cars?.FirstOrDefault(c => c.vin == vin);
            if (car == null)
            {
                return NotFound();
            }

            _db.cars?.Remove(car);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
