using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class DadosClinicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosClinicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadosClinicos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadosClinicos.ToListAsync());
        }

        // GET: DadosClinicos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosClinicos = await _context.DadosClinicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosClinicos == null)
            {
                return NotFound();
            }

            return View(dadosClinicos);
        }

        // GET: DadosClinicos/Create
        [Authorize]
        public IActionResult Create()
        {
            DadosClinicos dadosClinicos = new DadosClinicos
            {
                UtenteId = _context.Utente.ToList().LastOrDefault().Id
            };

            return View(dadosClinicos);
        }

        // POST: DadosClinicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,UtenteId,CentroSaude,MedicoAssistente,NumUtenteSaúde,GrupoSanguineo,Alergias,RestricoesAlimentare,Patologias,InformacoessComplementares,ResumoClinico")] DadosClinicos dadosClinicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosClinicos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Utentes");
            }
            return RedirectToAction("Index", "Utentes");
        }

        // GET: DadosClinicos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosClinicos = await _context.DadosClinicos.FindAsync(id);
            if (dadosClinicos == null)
            {
                return NotFound();
            }
            return View(dadosClinicos);
        }

        // POST: DadosClinicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtenteId,CentroSaude,MedicoAssistente,NumUtenteSaúde,GrupoSanguineo,Alergias,RestricoesAlimentare,Patologias,InformacoessComplementares,ResumoClinico")] DadosClinicos dadosClinicos)
        {
            if (id != dadosClinicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosClinicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosClinicosExists(dadosClinicos.Id))
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
            return View(dadosClinicos);
        }

        // GET: DadosClinicos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosClinicos = await _context.DadosClinicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosClinicos == null)
            {
                return NotFound();
            }

            return View(dadosClinicos);
        }

        // POST: DadosClinicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosClinicos = await _context.DadosClinicos.FindAsync(id);
            if (dadosClinicos != null)
            {
                _context.DadosClinicos.Remove(dadosClinicos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosClinicosExists(int id)
        {
            return _context.DadosClinicos.Any(e => e.Id == id);
        }
    }
}
