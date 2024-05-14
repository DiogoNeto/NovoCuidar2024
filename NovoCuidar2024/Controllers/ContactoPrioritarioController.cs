using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class ContactoPrioritarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoPrioritarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responsaveis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsavel.ToListAsync());
        }

        // GET: Responsaveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // GET: ContactoPrioritario/Create
        public IActionResult Create()
        {
            ContactoPrioritario contactoPrioritario = new ContactoPrioritario
            {
                UtenteId = _context.Utente.ToList().LastOrDefault().Id
            };


            return View(contactoPrioritario);
        }

        // POST: Responsaveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtenteId,Nome,Parentesco,Pais,Nif,Telefone,Email,Morada,NumPorta,Andar,Fracao,CodPostal,Localidade,Descricao,Concelho,Ativo")] ContactoPrioritario responsavel)
        {
            bool novoContacto = _context.Responsavel.Where(x => x.UtenteId == responsavel.UtenteId) != null;
            if (ModelState.IsValid)
            {
                _context.Add(responsavel);
                await _context.SaveChangesAsync();
                ViewBag.Data = _context.Utente;
                if (!novoContacto)
                {
                    return RedirectToAction("Create", "SubSistemas");
                }
                else
                {
                    return RedirectToAction("Details", "Utentes", new { id = responsavel.UtenteId });
                }
            }
            return View(responsavel);
        }

        // POST: Responsaveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IActionResult Add(int utenteId)
        {
            if (utenteId == null)
            {
                return NotFound();
            }

            ContactoPrioritario contactoPrioritario = new ContactoPrioritario
            {
                UtenteId = utenteId
                //_context.Utente.ToList().LastOrDefault().Id
            };

            return View(contactoPrioritario);
        }

        // GET: Responsaveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel.FindAsync(id);
            if (responsavel == null)
            {
                return NotFound();
            }
            return View(responsavel);
        }

        // POST: Responsaveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtenteId,Nome,Pais,Descricao,Parentesco,Nif,CC,SNS,NomePrincipal,NomeApelido,DataNascimento,Nacionalidade,Genero,Telefone,Email,Morada,CodPostal,Localidade,Concelho,EstadoCivil,Observações")] ContactoPrioritario responsavel)
        {
            if (id != responsavel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsavelExists(responsavel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Utentes", new { id = responsavel.UtenteId });
                //return RedirectToAction(nameof(Index));
            }
            return View(responsavel);
        }

        // GET: Responsaveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // POST: Responsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsavel = await _context.Responsavel.FindAsync(id);
            if (responsavel != null)
            {
                _context.Responsavel.Remove(responsavel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Utente", new { id = id });
        }

        private bool ResponsavelExists(int id)
        {
            return _context.Responsavel.Any(e => e.Id == id);
        }
    }
}
