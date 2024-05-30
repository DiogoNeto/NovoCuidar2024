using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class FamiliaUtentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamiliaUtentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FamiliaUtentes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.FamiliaUtentes.ToListAsync());
        }

        // GET: FamiliaUtentes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiaUtentes = await _context.FamiliaUtentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiaUtentes == null)
            {
                return NotFound();
            }

            return View(familiaUtentes);
        }

        // GET: FamiliaUtentes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamiliaUtentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Codigo")] FamiliaUtentes familiaUtentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiaUtentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familiaUtentes);
        }

        // GET: FamiliaUtentes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiaUtentes = await _context.FamiliaUtentes.FindAsync(id);
            if (familiaUtentes == null)
            {
                return NotFound();
            }
            return View(familiaUtentes);
        }

        // POST: FamiliaUtentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo")] FamiliaUtentes familiaUtentes)
        {
            if (id != familiaUtentes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiaUtentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaUtentesExists(familiaUtentes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(familiaUtentes);
        }

        // GET: FamiliaUtentes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiaUtentes = await _context.FamiliaUtentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiaUtentes == null)
            {
                return NotFound();
            }

            return View(familiaUtentes);
        }

        // POST: FamiliaUtentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familiaUtentes = await _context.FamiliaUtentes.FindAsync(id);
            if (familiaUtentes != null)
            {
                _context.FamiliaUtentes.Remove(familiaUtentes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaUtentesExists(int id)
        {
            return _context.FamiliaUtentes.Any(e => e.Id == id);
        }
    }
}
