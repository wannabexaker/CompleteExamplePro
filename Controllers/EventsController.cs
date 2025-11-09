
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompleteExampleApp.Data;
using CompleteExampleApp.Models.Entities;
using System.Linq;

namespace CompleteExampleApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        public EventsController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var q = _context.Events.Include(e=>e.Location).Include(e=>e.Organizer);
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Events.FirstOrDefaultAsync(e=>e.Id==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event model)
        {
            if (ModelState.IsValid)
            {
                if (model.DatePlanned.HasValue)
                    model.DatePlanned = DateTime.SpecifyKind(model.DatePlanned.Value, DateTimeKind.Utc);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Events.FindAsync(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Event model)
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
            var entity = await _context.Events.FirstOrDefaultAsync(e=>e.Id==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var entity = await _context.Events.FindAsync(id);
            if (entity != null) _context.Events.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
