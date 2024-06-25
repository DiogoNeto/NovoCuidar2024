﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;
using System.ComponentModel;
using System.Drawing;

namespace NovoCuidar2024.Controllers
{
    public class UtentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Utentes
        [Authorize]
        public async Task<IActionResult> Index(bool activo)
        {

            var query = @"SELECT u.Id, u.Nome as Nome, u.Ativo as Ativo, u.Foto as Foto, u.Apagado, t.Nome as NomeTecnica, s.Descricao as Descricao, s.Periodicidade as Periodicidade
                          FROM utente u
                          LEFT JOIN tecnico t ON t.Id = u.ResponsavelTecnicoId
                          LEFT JOIN servicocontratado s ON s.UtenteId = u.Id
                          Where u.Ativo !=" + activo +" AND u.Apagado = false";
            var result = _context.UtentesViewModel.FromSqlRaw(query).ToList();


            //verifica utentes ativos
            //var utentes = _context.Utente;
            var servicoContratado = _context.ServicoContratado;
            var utente = _context.Utente;

            for (int i = 0; i < servicoContratado.Count(); i++)
            {
                try
                {
                    DateOnly dataFim = servicoContratado.ElementAt(i).DataFim.Value;
                    if (servicoContratado.ElementAt(i).DataFim == null)
                    {
                        dataFim = DateOnly.MaxValue;
                    }
                    int dateCompare = DateTime.Today.CompareTo(dataFim);
                    var entity = _context.Utente.FirstOrDefault(e => e.Id == servicoContratado.ElementAt(i).UtenteId);
                    if (dateCompare >= 0)
                    {
                        entity.Ativo = true;
                    }
                    else
                    {
                        entity.Ativo = false;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            _context.SaveChanges();


            var Utentes = _context.Utente;
            var Tecnicos = _context.Tecnico;
            var Servicos = _context.ServicoContratado;
            var viewModel = new UtentesViewModel
            {
                //Utente = Utentes.ToList(),
                //Tecnicos = Tecnicos.ToList().Where(x => x.Id == Utentes.First().ResponsavelTecnicoId).ToList(),
                //Servicos = Servicos.ToList().Where(x => x.UtenteId == Utentes.First().Id).ToList()
            };

            IEnumerable<UtentesViewModel> listUtentes = result;

            return View(listUtentes);
        }


        // GET: Utentes
        [Authorize]
        public async Task<IActionResult> Removed(bool activo)
        {

            var query = @"SELECT u.Id, u.Nome as Nome, u.Ativo as Ativo, u.Foto as Foto, u.Apagado, t.Nome as NomeTecnica, s.Descricao as Descricao, s.Periodicidade as Periodicidade
                          FROM utente u
                          LEFT JOIN tecnico t ON t.Id = u.ResponsavelTecnicoId
                          LEFT JOIN servicocontratado s ON s.UtenteId = u.Id
                          Where u.Apagado =" + true;
            var result = _context.UtentesViewModel.FromSqlRaw(query).ToList();


            //verifica utentes ativos
            //var utentes = _context.Utente;
            var servicoContratado = _context.ServicoContratado;
            var utente = _context.Utente;

            for (int i = 0; i < servicoContratado.Count(); i++)
            {
                try
                {
                    DateOnly dataFim = servicoContratado.ElementAt(i).DataFim.Value;
                    if (servicoContratado.ElementAt(i).DataFim == null)
                    {
                        dataFim = DateOnly.MaxValue;
                    }
                    int dateCompare = DateTime.Today.CompareTo(dataFim);
                    var entity = _context.Utente.FirstOrDefault(e => e.Id == servicoContratado.ElementAt(i).UtenteId);
                    if (dateCompare >= 0)
                    {
                        entity.Ativo = true;
                    }
                    else
                    {
                        entity.Ativo = false;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            _context.SaveChanges();


            var Utentes = _context.Utente;
            var Tecnicos = _context.Tecnico;
            var Servicos = _context.ServicoContratado;
            var viewModel = new UtentesViewModel
            {
                //Utente = Utentes.ToList(),
                //Tecnicos = Tecnicos.ToList().Where(x => x.Id == Utentes.First().ResponsavelTecnicoId).ToList(),
                //Servicos = Servicos.ToList().Where(x => x.UtenteId == Utentes.First().Id).ToList()
            };

            IEnumerable<UtentesViewModel> listUtentes = result;

            return View(listUtentes);
        }

        // GET: Utentes/Details/5   
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }


            ViewBag.Utente = utente;

            List<ServicoContratado> servicoContratado = new List<ServicoContratado>();
            foreach (var v in _context.ServicoContratado.Where(m => m.Id == id))
            {
                servicoContratado.Add(v);
            }

            for (var i = 0; i < servicoContratado.Count; i++)
            {
                var contrato = _context.Contrato.Where(x => x.Id == servicoContratado[i].ContratoId).FirstOrDefault().Descricao;
                ViewBag.DescricaoContrato = contrato;
                var servico = _context.Servico.Where(x => x.Id == servicoContratado[i].ServicoId).FirstOrDefault().Nome;
                ViewBag.NomeServico = servico;
                var servicoDescricao = _context.Servico.Where(x => x.Id == servicoContratado[i].ServicoId).FirstOrDefault().Descricao;
                ViewBag.DescricaoServico = servicoDescricao;
            }

            ViewBag.ServicoContratado = servicoContratado;

            List<MoradaUtente> morada = new List<MoradaUtente>();
            foreach (var v in _context.MoradaUtente.Where(m => m.UtenteId == id))
            {
                morada.Add(v);
            }
            ViewBag.Morada = morada;



            List<ContactoPrioritario> contact = new List<ContactoPrioritario>();
            foreach (var r in _context.Responsavel.Where(m => m.UtenteId == id))
            {
                contact.Add(r);
            }

            ViewBag.ContactoPrioritario = contact;

            List<SubSistema> subSistema = new List<SubSistema>();
            foreach (var s in _context.SubSistema.Where(m => m.UtenteId == id))
            {
                subSistema.Add(s);
            }

            ViewBag.SubSistema = subSistema;

            var dadosClinicos = _context.DadosClinicos.FirstOrDefault(m => m.UtenteId == id);
            ViewBag.DadosClinicos = dadosClinicos;

            var dadosSociais = _context.DadosSociais.FirstOrDefault(m => m.UtenteId == id);
            ViewBag.DadosSociais = dadosSociais;

            List<Visita> visitas = new List<Visita>();
            foreach (var v in _context.Visita.Where(m => m.UtenteId == id))
            {
                visitas.Add(v);
            }

            //var linhasEscala = _context.LinhaEscala.FirstOrDefault(m => m.UtenteId == id);
            ViewBag.Visitas = visitas;

            return View(utente);
        }

        // GET: Utentes/Create
        [Authorize]
        public IActionResult Create()
        {
            var dataResponsavelTecnico = _context.Tecnico.ToList();
            var dataFamilia = _context.FamiliaUtentes.ToList();
            var utente = _context.Utente.ToList();
            var dataOrigemContacto = _context.OrigemContacto.ToList();

            ViewBag.DataResponsavel = dataResponsavelTecnico;
            ViewBag.DataFamilia = dataFamilia;
            ViewBag.Utente = utente;
            ViewBag.DataOrigemContacto = dataOrigemContacto;

            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,IdInterno,Nome,Foto,ResponsavelTecnicoId,FamiliaId,Ativo,DataInscricao,OrigemContacto,Nif,Genero,DataNascimento,EstadoCivil,DocIdentificacaoTipo,DocIdentificacaoNum,DocIdentificacaoValidade,SegurancaSocialNum,Nacionalidade,ContactoTelemovel,ContactoEmail,Habilitacoes,Vivencia,HabitacaoTipo,HabitacaoPartilhada,NomeEmpresa,Foto,DataCriacao,DataAtualizacao,UtilizadorCriador,UtilizadorAtualizador,Apagado")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                var uploadsDirectoryLeitura = "C:\\NovoCuidar\\Fotos\\";
                var uploadsDirectoryEscrita = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var filePathLeitura = Path.Combine(uploadsDirectoryLeitura, utente.Foto);
                var filePathEscrita = Path.Combine(uploadsDirectoryEscrita, utente.Foto);

                Image? image = null;

                try
                {
                    image = Image.FromFile(filePathLeitura);
                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    var bytess = ms.ToArray();
                    image.Dispose();
                    System.IO.File.WriteAllBytes(filePathEscrita, bytess);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + " - Erro ao carregar a imagem.");
                }


                utente.DataCriacao = DateTime.Now;
                utente.UtilizadorCriador = User.Identity.Name;
                utente.Apagado = false;
                _context.Add(utente);
                await _context.SaveChangesAsync();
                ViewBag.Data = _context.Utente;

                return RedirectToAction("Create", "MoradaUtentes");
            }
            return View(utente);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.FindAsync(id);

            var dataResponsavelTecnico = _context.Tecnico.ToList();
            var dataFamilia = _context.FamiliaUtentes.ToList();
            var dataOrigemContacto = _context.OrigemContacto.ToList();
            

            ViewBag.DataResponsavel = dataResponsavelTecnico;
            ViewBag.SelectedResponsavel = utente.ResponsavelTecnicoId;
            ViewBag.DataFamilia = dataFamilia;
            ViewBag.DataOrigemContacto = dataOrigemContacto;
            ViewBag.EstadoCivil = utente.EstadoCivil;
            ViewBag.DocIdentificacaoTipo = utente.DocIdentificacaoTipo;
            ViewBag.Nacionalidade = utente.Nacionalidade;
            ViewBag.Habilitacoes = utente.Habilitacoes;
            ViewBag.Vivencia = utente.Vivencia;
            ViewBag.HabitacaoTipo = utente.HabitacaoTipo;
            ViewBag.HabitacaoPartilhada = utente.HabitacaoPartilhada;
            ViewBag.NomeEmpresa = utente.NomeEmpresa;
            ViewBag.OrigemContacto = utente.OrigemContacto;
            ViewBag.Genero = utente.Genero;
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdInterno,Nome,Foto,ResponsavelTecnicoId,FamiliaId,Ativo,DataInscricao,OrigemContacto,Nif,Genero,DataNascimento,EstadoCivil,DocIdentificacaoTipo,DocIdentificacaoNum,DocIdentificacaoValidade,SegurancaSocialNum,Nacionalidade,ContactoTelemovel,ContactoEmail,Habilitacoes,Vivencia,HabitacaoTipo,HabitacaoPartilhada,NomeEmpresa,Foto,DataCriacao,DataAtualizacao,UtilizadorCriador,UtilizadorAtualizador,Apagado")] Utente utente)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    utente.DataAtualizacao = DateTime.Now;
                    utente.UtilizadorAtualizador = User.Identity.Name;
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Utentes", new { id = utente.Id });
            }
            return RedirectToAction("Edit", "Utentes", new { id = utente.Id });
        }

        // GET: Utentes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utente = await _context.Utente.FindAsync(id);
            //if (utente != null)
            //{
            //    _context.Utente.Remove(utente);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));



            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    utente.DataAtualizacao = DateTime.Now;
                    utente.UtilizadorAtualizador = User.Identity.Name;
                    utente.Apagado = true;
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Removed", "Utentes", new { id = utente.Id });
            }
            return RedirectToAction("Details", "Utentes", new { id = utente.Id });
        }


        // POST: Utentes/Delete/5
        [ActionName("Revert")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Revert(int id)
        {
            var utente = await _context.Utente.FindAsync(id);
            //if (utente != null)
            //{
            //    _context.Utente.Remove(utente);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));



            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    utente.DataAtualizacao = DateTime.Now;
                    utente.UtilizadorAtualizador = User.Identity.Name;
                    utente.Apagado = false;
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Utentes", new { id = utente.Id });
            }
         return RedirectToAction("Success"); ;
        }

        private bool UtenteExists(int id)
        {
            return _context.Utente.Any(e => e.Id == id);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                // Handle empty or missing file
                return RedirectToAction("Error");
            }

            // Save the uploaded photo to a directory on the server
            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            var filePath = Path.Combine(uploadsDirectory, photo.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            // Store the file path in the MySQL database
            // Add your database logic here

            return RedirectToAction("Success");
        }
    }
}
