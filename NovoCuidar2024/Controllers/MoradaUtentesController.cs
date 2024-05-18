using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Migrations;
using NovoCuidar2024.Models;
using System.Reflection.PortableExecutable;

namespace NovoCuidar2024.Controllers
{
    public class MoradaUtentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoradaUtentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoradaUtentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoradaUtente.ToListAsync());
        }

        // GET: Subsistemas/Add
        public IActionResult Add(int utenteId)
        {
            if (utenteId == null)
            {
                return NotFound();
            }

            MoradaUtente morada = new MoradaUtente
            {
                UtenteId = utenteId

            };
            
            return View(morada);
        }

        // GET: MoradaUtentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradaUtente = await _context.MoradaUtente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moradaUtente == null)
            {
                return NotFound();
            }

            return View(moradaUtente);
        }

        // GET: MoradaUtentes/Create
        public IActionResult Create()
        {
            MoradaUtente moradaUtentes = new MoradaUtente
            {
                UtenteId = _context.Utente.ToList().LastOrDefault().Id
            };
            return View(moradaUtentes);
        }

        // POST: MoradaUtentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtenteId,Morada,CodPostal,Localidade,Concelho,NumPorta,Andar,Fracao,CodPostal,Pais")] MoradaUtente moradaUtente)
        {
            var novoContacto = _context.Utente.Where(x => x.Id == moradaUtente.UtenteId).Count();

            if (ModelState.IsValid)
            {
                _context.Add(moradaUtente);
                await _context.SaveChangesAsync();
                ViewBag.Data = _context.MoradaUtente;
            }
            if (novoContacto == 0)
            {
                return RedirectToAction("Create", "ContactoPrioritario");
            }
            else
            {
                return RedirectToAction("Details", "Utentes", new { id = moradaUtente.UtenteId });
            }
        }

        // GET: MoradaUtentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradaUtente = await _context.MoradaUtente.FindAsync(id);
            if (moradaUtente == null)
            {
                return NotFound();
            }
            return View(moradaUtente);
        }

        // POST: MoradaUtentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtenteId,Pais,Fracao,Andar,NumPorta,Morada,CodPostal,Localidade,Concelho")] MoradaUtente moradaUtente)
        {
            if (id != moradaUtente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moradaUtente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradaUtenteExists(moradaUtente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Utentes", new { id = moradaUtente.UtenteId });
            }
            return View(moradaUtente);
        }

        // GET: MoradaUtentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradaUtente = await _context.MoradaUtente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moradaUtente == null)
            {
                return NotFound();
            }

            return View(moradaUtente);
        }

        // POST: MoradaUtentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moradaUtente = await _context.MoradaUtente.FindAsync(id);
            if (moradaUtente != null)
            {
                _context.MoradaUtente.Remove(moradaUtente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Utentes", new { id = moradaUtente.UtenteId });
        }

        private bool MoradaUtenteExists(int id)
        {
            return _context.MoradaUtente.Any(e => e.Id == id);
        }
    }
}
