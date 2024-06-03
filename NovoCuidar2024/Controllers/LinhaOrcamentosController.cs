using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class LinhaOrcamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinhaOrcamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LinhaOrcamentos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinhaOrcamento.ToListAsync());
        }

        // GET: LinhaOrcamentos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaOrcamento = await _context.LinhaOrcamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaOrcamento == null)
            {
                return NotFound();
            }

            return View(linhaOrcamento);
        }

        // GET: LinhaOrcamentos/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinhaOrcamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,OrcamentoId,UtenteId,ServicoId,Preco,Data")] LinhaOrcamento linhaOrcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhaOrcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhaOrcamento);
        }

        // GET: LinhaOrcamentos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaOrcamento = await _context.LinhaOrcamento.FindAsync(id);
            if (linhaOrcamento == null)
            {
                return NotFound();
            }
            return View(linhaOrcamento);
        }

        // POST: LinhaOrcamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrcamentoId,UtenteId,ServicoId,Preco,Data")] LinhaOrcamento linhaOrcamento)
        {
            if (id != linhaOrcamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaOrcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaOrcamentoExists(linhaOrcamento.Id))
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
            return View(linhaOrcamento);
        }

        // GET: LinhaOrcamentos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaOrcamento = await _context.LinhaOrcamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaOrcamento == null)
            {
                return NotFound();
            }

            return View(linhaOrcamento);
        }

        // POST: LinhaOrcamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linhaOrcamento = await _context.LinhaOrcamento.FindAsync(id);
            if (linhaOrcamento != null)
            {
                _context.LinhaOrcamento.Remove(linhaOrcamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaOrcamentoExists(int id)
        {
            return _context.LinhaOrcamento.Any(e => e.Id == id);
        }
    }
}
