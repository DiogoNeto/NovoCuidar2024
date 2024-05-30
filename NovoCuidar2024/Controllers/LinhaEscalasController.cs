using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using Microsoft.AspNetCore.Authorization;

namespace NovoCuidar2024.Controllers
{
    public class LinhaEscalasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinhaEscalasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LinhaEscalas
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinhaEscala.ToListAsync());
        }

        // GET: LinhaEscalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaEscala = await _context.LinhaEscala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaEscala == null)
            {
                return NotFound();
            }

            return View(linhaEscala);
        }

        // GET: LinhaEscalas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinhaEscalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CuidadoraId,ServicoContratadoId,DataHoraInicio,DataHoraFim,ValorReceberInicial,ValorPago,ValorReceberAtualizado")] LinhaEscala linhaEscala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhaEscala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhaEscala);
        }

        // GET: LinhaEscalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaEscala = await _context.LinhaEscala.FindAsync(id);
            if (linhaEscala == null)
            {
                return NotFound();
            }
            return View(linhaEscala);
        }

        // POST: LinhaEscalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CuidadoraId,ServicoContratadoId,DataHoraInicio,DataHoraFim,ValorReceberInicial,ValorPago,ValorReceberAtualizado")] LinhaEscala linhaEscala)
        {
            if (id != linhaEscala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaEscala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaEscalaExists(linhaEscala.Id))
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
            return View(linhaEscala);
        }

        // GET: LinhaEscalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaEscala = await _context.LinhaEscala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaEscala == null)
            {
                return NotFound();
            }

            return View(linhaEscala);
        }

        // POST: LinhaEscalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linhaEscala = await _context.LinhaEscala.FindAsync(id);
            if (linhaEscala != null)
            {
                _context.LinhaEscala.Remove(linhaEscala);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaEscalaExists(int id)
        {
            return _context.LinhaEscala.Any(e => e.Id == id);
        }
    }
}
