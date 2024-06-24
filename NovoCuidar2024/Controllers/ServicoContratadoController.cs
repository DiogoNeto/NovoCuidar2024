﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;
using System;
using System.ComponentModel;
using System.Globalization;

namespace NovoCuidar2024.Controllers
{
    public class ServicoContratadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicoContratadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicoContratado
        [Authorize]
        public async Task<IActionResult> Index(int? utenteId)
        {
            var query = @"SELECT u.Id, u.Nome as Nome, u.Ativo as Ativo, u.Foto as Foto, t.Nome as NomeTecnica, s.Descricao as Descricao, s.Periodicidade as Periodicidade
                          FROM utente u
                          LEFT JOIN tecnico t ON t.Id = u.ResponsavelTecnicoId
                          LEFT JOIN servicocontratado s ON s.UtenteId = u.Id;";
                          
            //var resul = _context.Utente.FromSqlRaw(query).ToList();
            var result = _context.UtentesViewModel.FromSqlRaw(query).ToList();

            var viewModel = new LinhaEscalaViewModel { };
            IEnumerable<LinhaEscalaViewModel> servicoContratadoViewModels;
            if (utenteId == null)
            {
                return View(await _context.ServicoContratado.ToListAsync());
            }
            else
            {
                return RedirectToAction("Details", "Utentes", new { id = utenteId });
            }
        }

        // GET: ServicoContratado/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicoContratado = await _context.ServicoContratado
                .FirstOrDefaultAsync(m => m.Id == id);
           

            if (servicoContratado == null)
            {
                return NotFound();
            }
            
            return View(servicoContratado);
        }

        // GET: ServicoContratado/Create
        [Authorize]
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utentes = _context.Utente.Where(x => x.Id == id);
            var nome = utentes.FirstOrDefault().Nome;

            var servicos = _context.Servico;
            var contratos = _context.Contrato;

            var servicosList = servicos.Select(x => new { x.Nome, x.Id }).ToList();
            var contratosList = contratos.Select(x => new { x.Descricao, x.Id }).ToList();

            ViewBag.Nome = nome;
            ViewBag.DataServicos = servicosList;
            ViewBag.DataContratos = contratosList;

            ServicoContratado servicoContratado = new ServicoContratado
            {
                UtenteId = utentes.FirstOrDefault().Id,
                //DataInicio = DateOnly.FromDateTime(DateTime.Now)
            };
            //DateOnly res = DateOnly.ParseExact(DateOnly.FromDateTime(DateTime.Now).ToString(), "dd MM yyyy", CultureInfo.InvariantCulture);
            return View(servicoContratado);
        }


        // POST: ServicoContratado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,UtenteId,ServicoId,ContratoId,Descricao,DataInicio,DataFim,Periodicidade,ValorDia,ValorSemana,ValorMes")] ServicoContratado servicoContratado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicoContratado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Utentes", new { id = servicoContratado.UtenteId });
            }
            return RedirectToAction("Details", "Utentes", new { id = servicoContratado.UtenteId });

        }

        // GET: ServicoContratado/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicoContratado = await _context.ServicoContratado.FindAsync(id);
            if (servicoContratado == null)
            {
                return NotFound();
            }
            return View(servicoContratado);
        }

        // POST: ServicoContratado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtenteId,ServicoId,ContratoId,DataInicio,DataFim,Periodicidade,ValorDia,ValorSemana,ValorMes")] ServicoContratado servicoContratado)
        {
            if (id != servicoContratado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicoContratado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoContratadoExists(servicoContratado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Utentes", new { id = servicoContratado.UtenteId });
            }
            return RedirectToAction("Details", "Utentes", new { id = servicoContratado.UtenteId });
        }

        // GET: ServicoContratado/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicoContratado = await _context.ServicoContratado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicoContratado == null)
            {
                return NotFound();
            }

            return View(servicoContratado);
        }

        // POST: ServicoContratado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicoContratado = await _context.ServicoContratado.FindAsync(id);
            if (servicoContratado != null)
            {
                _context.ServicoContratado.Remove(servicoContratado);
            }

            await _context.SaveChangesAsync();
            
            return RedirectToAction("Details", "Utentes", new { id = servicoContratado.UtenteId });
        }

        private bool ServicoContratadoExists(int id)
        {
            return _context.ServicoContratado.Any(e => e.Id == id);
        }
    }
}
