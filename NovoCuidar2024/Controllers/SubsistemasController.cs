using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class SubSistemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubSistemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subsistemas
        public async Task<IActionResult> Index()
        {
            //var utentes = await _context.Utente.ToListAsync();
            return View(await _context.SubSistema.ToListAsync());
        }

        // GET: Subsistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsistema = await _context.SubSistema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subsistema == null)
            {
                return NotFound();
            }

            return View(subsistema);
        }

        // GET: Subsistemas/Add
        public IActionResult Add(int utenteId)
        {
            if (utenteId == null)
            {
                return NotFound();
            }

            SubSistema subSistema = new SubSistema
            {
                UtenteId = utenteId

            };

            var DataSubsistemas = _context.SubSistema.Where(x => x.UtenteId == 0).ToList();
            ViewBag.DataSubSistemas = DataSubsistemas;

            // _context.SaveChangesAsync();
            //ViewBag.Data = _context.Utente;


            return View(subSistema);
        }


        // GET: Subsistemas/Create
        public IActionResult Create()
        {
            SubSistema subSistema = new SubSistema
            {
                UtenteId = _context.Utente.ToList().LastOrDefault().Id
            };
            var DataSubsistemas = _context.SubSistema.Where(x=>x.UtenteId==0).ToList();
            ViewBag.DataSubSistemas = DataSubsistemas;
            return View(subSistema);
        }

        // POST: Subsistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtenteId,Nome")] SubSistema subsistema)
        {
            var novoContacto = _context.Utente.Where(x => x.Id == subsistema.UtenteId).Count();

            if (ModelState.IsValid)
            {
                _context.Add(subsistema);
                await _context.SaveChangesAsync();
                ViewBag.Data = _context.Utente;
                if (novoContacto==0)
                {
                    return RedirectToAction("Create", "DadosClinicos");
                }
                else
                {
                    return RedirectToAction("Details", "Utentes", new { id = subsistema.UtenteId });
                }
            }
            return View(subsistema);
        }

        // GET: Subsistemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsistema = await _context.SubSistema.FindAsync(id);
            if (subsistema == null)
            {
                return NotFound();
            }
            return View(subsistema);
        }

        // POST: Subsistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] SubSistema subsistema)
        {
            if (id != subsistema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subsistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubSistemaExists(subsistema.Id))
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
            return View(subsistema);
        }

        // GET: Subsistemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsistema = await _context.SubSistema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subsistema == null)
            {
                return NotFound();
            }

            return View(subsistema);
        }

        // POST: Subsistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subsistema = await _context.SubSistema.FindAsync(id);
            if (subsistema != null)
            {
                _context.SubSistema.Remove(subsistema);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Utentes", new { id = subsistema.UtenteId });
            //return RedirectToAction(nameof(Index));
        }

        private bool SubSistemaExists(int id)
        {
            return _context.SubSistema.Any(e => e.Id == id);
        }
    }
}
