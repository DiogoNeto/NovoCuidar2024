using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class OrigemContactosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrigemContactosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrigemContactos
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrigemContacto.ToListAsync());
        }

        // GET: OrigemContactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origemContacto = await _context.OrigemContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origemContacto == null)
            {
                return NotFound();
            }

            return View(origemContacto);
        }

        // GET: OrigemContactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrigemContactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] OrigemContacto origemContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origemContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origemContacto);
        }

        // GET: OrigemContactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origemContacto = await _context.OrigemContacto.FindAsync(id);
            if (origemContacto == null)
            {
                return NotFound();
            }
            return View(origemContacto);
        }

        // POST: OrigemContactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] OrigemContacto origemContacto)
        {
            if (id != origemContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(origemContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrigemContactoExists(origemContacto.Id))
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
            return View(origemContacto);
        }

        // GET: OrigemContactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origemContacto = await _context.OrigemContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origemContacto == null)
            {
                return NotFound();
            }

            return View(origemContacto);
        }

        // POST: OrigemContactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var origemContacto = await _context.OrigemContacto.FindAsync(id);
            if (origemContacto != null)
            {
                _context.OrigemContacto.Remove(origemContacto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrigemContactoExists(int id)
        {
            return _context.OrigemContacto.Any(e => e.Id == id);
        }
    }
}
