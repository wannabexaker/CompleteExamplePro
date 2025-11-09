using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompleteExampleApp.Data;
using CompleteExampleApp.Models.Entities;
using System.Linq;

namespace CompleteExampleApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly AppDbContext _context;
        public LocationsController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var q = _context.Locations;
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Locations.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        // GET: Locations/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location model)
        {
            if (ModelState.IsValid)
            {
                var cityExists = await _context.Cities.AnyAsync(c => c.Name == model.CityName);
                if (!cityExists)
                {
                    ModelState.AddModelError("CityName", "City does not exist. Please add it first in Cities.");
                    return View(model);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Locations.FindAsync(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Location model)
        {
            if (id != model.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Locations.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity != null) _context.Locations.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
