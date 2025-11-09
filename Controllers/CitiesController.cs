
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompleteExampleApp.Data;
using CompleteExampleApp.Models.Entities;
using System.Linq;

namespace CompleteExampleApp.Controllers
{
    public class CitiesController : Controller
    {
        private readonly AppDbContext _context;
        public CitiesController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var q = _context.Cities;
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Cities.FirstOrDefaultAsync(e=>e.Name==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Cities.FindAsync(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string? id, City model)
        {
            if (id != model.Name) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Cities.FirstOrDefaultAsync(e=>e.Name==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            var entity = await _context.Cities.FindAsync(id);
            if (entity != null) _context.Cities.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
