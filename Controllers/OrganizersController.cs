
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompleteExampleApp.Data;
using CompleteExampleApp.Models.Entities;
using System.Linq;

namespace CompleteExampleApp.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly AppDbContext _context;
        public OrganizersController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var q = _context.Organizers;
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Organizers.FirstOrDefaultAsync(e=>e.UserId==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organizer model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Organizers.FindAsync(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Organizer model)
        {
            if (id != model.UserId) return NotFound();
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
            var entity = await _context.Organizers.FirstOrDefaultAsync(e=>e.UserId==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var entity = await _context.Organizers.FindAsync(id);
            if (entity != null) _context.Organizers.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
