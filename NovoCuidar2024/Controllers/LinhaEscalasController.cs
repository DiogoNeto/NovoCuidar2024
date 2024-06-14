using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;
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
        public async Task<IActionResult> Index(int? utenteId)
        {
            var query = @"SELECT le.Id, u.id as UtenteId, u.nome as UtenteNome, c.nome as CuidadoraNome, sc.Descricao, le.DataHoraInicio, le.DataHoraFim, le.ValorReceberInicial as ValorReceber, s.Nome as TipoServico FROM linhaescala le
                            LEFT JOIN cuidadora c ON CuidadoraId = c.Id
                            LEFT JOIN servicocontratado sc ON sc.Id = ServicoContratadoId
                            LEFT JOIN utente u ON u.id = sc.utenteId
                            LEFT JOIN servico s ON s.Id = sc.ServicoId";
            //_context.LinhaEscala
            var result = _context.LinhasEscalaViewModel.FromSqlRaw(query).ToList();

            //var viewModel = new LinhaEscalaViewModel { };
            //IEnumerable<LinhaEscalaViewModel> servicoContratadoViewModels;

            if (utenteId == null)
            {
                IEnumerable<LinhaEscalaViewModel> listaLinhasEscala = result;
                return View(listaLinhasEscala);
            }
            else
            {
                IEnumerable<LinhaEscalaViewModel> listaLinhasEscala = result;
                return View(listaLinhasEscala.Where(x => x.UtenteId == utenteId));
            }
        }

        // GET: LinhaEscalas/Details/5
        [Authorize]
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
        [Authorize]
        public IActionResult Create()
        {
            var dataCuidadora = _context.Cuidadora.ToList();
            ViewBag.DataCuidadora = dataCuidadora;

            var dataServicoContratado = _context.ServicoContratado.ToList();
            ViewBag.ServicoContratado = dataServicoContratado;

            return View();
        }

        // POST: LinhaEscalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaEscala = await _context.LinhaEscala.FindAsync(id);
            linhaEscala.ValorReceberAtualizado = linhaEscala.ValorReceberInicial - linhaEscala.ValorPago;
            if (linhaEscala == null)
            {
                return NotFound();
            }

            var dataCuidadora = _context.Cuidadora.ToList();
            ViewBag.DataCuidadora = dataCuidadora;
            ViewBag.SelectedCuidadora = linhaEscala.CuidadoraId;

            var dataServicoContratado = _context.ServicoContratado.ToList();
            ViewBag.ServicoContratado = dataServicoContratado;
            ViewBag.SelectedServicoContratado = linhaEscala.ServicoContratadoId;

            return View(linhaEscala);
        }

        // POST: LinhaEscalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [HttpPost]
        public IActionResult OnChange(string selectedValue)
        {
            // Aqui você pode fazer algo com o valor selecionado
            // Por exemplo, retornar uma mensagem ou atualizar algo no servidor
            return Json(new { message = "Valor recebido: " + selectedValue });
        }
    }
}
