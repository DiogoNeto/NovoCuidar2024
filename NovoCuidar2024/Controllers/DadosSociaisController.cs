using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;

namespace NovoCuidar2024.Controllers
{
    public class DadosSociaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosSociaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadosSociais
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadosSociais.ToListAsync());
        }

        // GET: DadosSociais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosSociais = await _context.DadosSociais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosSociais == null)
            {
                return NotFound();
            }

            return View(dadosSociais);
        }

        // GET: DadosSociais/Create
        public IActionResult Create(int utenteId)
        {
            if (utenteId == null)
            {
                return NotFound();
            }

            Models.DadosSociais dadosSociais = new Models.DadosSociais
            {
                UtenteId = utenteId
            };
            return View(dadosSociais);
        }

        // POST: DadosSociais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtenteId,RespostaSocial,ApoioSolicitado,OutrosApoios,ResumoSocial")] Models.DadosSociais dadosSociais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosSociais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadosSociais);
        }

        // GET: DadosSociais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosSociais = await _context.DadosSociais.FindAsync(id);
            if (dadosSociais == null)
            {
                return NotFound();
            }

            return View(dadosSociais);
        }

        // POST: DadosSociais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtenteId,RespostaSocial,ApoioSolicitado,OutrosApoios,ResumoSocial")] Models.DadosSociais dadosSociais)
        {
            if (id != dadosSociais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosSociais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosSociaisExists(dadosSociais.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Utentes", new { id = dadosSociais.UtenteId });

                //return RedirectToAction(nameof(Index));
            }
            return View(dadosSociais);
        }

        // GET: DadosSociais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosSociais = await _context.DadosSociais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosSociais == null)
            {
                return NotFound();
            }

            return View(dadosSociais);
        }

        // POST: DadosSociais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosSociais = await _context.DadosSociais.FindAsync(id);
            if (dadosSociais != null)
            {
                _context.DadosSociais.Remove(dadosSociais);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosSociaisExists(int id)
        {
            return _context.DadosSociais.Any(e => e.Id == id);
        }
    }
}
