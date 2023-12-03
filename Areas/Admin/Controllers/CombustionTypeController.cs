using Microsoft.AspNetCore.Mvc;
using EvidentaMasini.Data;
using EvidentaMasini.Models;

namespace EvidentaMasini.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CombustionTypeController : Controller
    {
        private ApplicationDbContext? _db;

        public CombustionTypeController(ApplicationDbContext? db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db?.combustionTypes?.ToList();
            return View(data);
        }

        //GET CREATE method
        public ActionResult Create()
        {
            return View();
        }

        //POST Create Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CombustionType combustionType)
        {
            if (ModelState.IsValid)
            {
                _db?.combustionTypes?.Add(combustionType);
                await _db!.SaveChangesAsync();
                TempData["save"] = "Combustion type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(combustionType);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db?.combustionTypes?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CombustionType combustionType)
        {
            if (ModelState.IsValid)
            {
                _db!.Update(combustionType);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Combustion type has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(combustionType);
        }


        //GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db?.combustionTypes?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(CombustionType combustionType)
        {
            return RedirectToAction(nameof(Index));

        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db?.combustionTypes?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, CombustionType combustionType)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != combustionType.combustionId)
            {
                return NotFound();
            }

            var productCategory = _db?.combustionTypes?.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db!.Remove(productCategory);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Combustion type has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return View(productCategory);
        }
    }
}
