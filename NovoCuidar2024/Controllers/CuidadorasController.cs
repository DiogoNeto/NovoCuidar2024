using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Controllers
{
    public class CuidadorasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuidadorasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuidadoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuidadora.ToListAsync());
        }

        // GET: Cuidadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidadora = await _context.Cuidadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidadora == null)
            {
                return NotFound();
            }

            return View(cuidadora);
        }

        // GET: Cuidadoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuidadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NIF,Contacto,ContactoWhatsapp,NIB,Observacoes")] Cuidadora cuidadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuidadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuidadora);
        }

        // GET: Cuidadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidadora = await _context.Cuidadora.FindAsync(id);
            if (cuidadora == null)
            {
                return NotFound();
            }
            return View(cuidadora);
        }

        // POST: Cuidadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NIF,Contacto,ContactoWhatsapp,NIB,Observacoes")] Cuidadora cuidadora)
        {
            if (id != cuidadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuidadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuidadoraExists(cuidadora.Id))
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
            return View(cuidadora);
        }

        // GET: Cuidadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidadora = await _context.Cuidadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidadora == null)
            {
                return NotFound();
            }

            return View(cuidadora);
        }

        // POST: Cuidadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuidadora = await _context.Cuidadora.FindAsync(id);
            if (cuidadora != null)
            {
                _context.Cuidadora.Remove(cuidadora);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuidadoraExists(int id)
        {
            return _context.Cuidadora.Any(e => e.Id == id);
        }
    }
}
