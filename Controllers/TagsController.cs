
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompleteExampleApp.Data;
using CompleteExampleApp.Models.Entities;
using System.Linq;

namespace CompleteExampleApp.Controllers
{
    public class TagsController : Controller
    {
        private readonly AppDbContext _context;
        public TagsController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var q = _context.Tags;
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null) return NotFound();
            var entity = await _context.Tags.FirstOrDefaultAsync(e=>e.Name==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag model)
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
            var entity = await _context.Tags.FindAsync(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string? id, Tag model)
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
            var entity = await _context.Tags.FirstOrDefaultAsync(e=>e.Name==id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            var entity = await _context.Tags.FindAsync(id);
            if (entity != null) _context.Tags.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
