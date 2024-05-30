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
    public class AdendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adendas
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adendas.ToListAsync());
        }

        // GET: Adendas/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adendas = await _context.Adendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adendas == null)
            {
                return NotFound();
            }

            return View(adendas);
        }

        // GET: Adendas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,ContratoId,Descricao,Ficheiro")] Adendas adendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adendas);
        }

        // GET: Adendas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adendas = await _context.Adendas.FindAsync(id);
            if (adendas == null)
            {
                return NotFound();
            }
            return View(adendas);
        }

        // POST: Adendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContratoId,Descricao,Ficheiro")] Adendas adendas)
        {
            if (id != adendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdendasExists(adendas.Id))
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
            return View(adendas);
        }

        // GET: Adendas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adendas = await _context.Adendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adendas == null)
            {
                return NotFound();
            }

            return View(adendas);
        }

        // POST: Adendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adendas = await _context.Adendas.FindAsync(id);
            if (adendas != null)
            {
                _context.Adendas.Remove(adendas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdendasExists(int id)
        {
            return _context.Adendas.Any(e => e.Id == id);
        }
    }
}
