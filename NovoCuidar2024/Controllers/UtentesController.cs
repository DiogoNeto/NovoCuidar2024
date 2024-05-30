using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;
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
            //var items = _context.Utente.ToList();

            //return View(await _context.Utente.Where(x=>x.Ativo!=activo).OrderByDescending(x=>x.Id).ToListAsync());

            var query = @"SELECT u.Id, u.Nome as Nome, u.Ativo as Ativo, u.Foto as Foto, t.Nome as NomeTecnica, s.Descricao as Descricao, s.Periodicidade as Periodicidade
                          FROM utente u
                          LEFT JOIN tecnico t ON t.Id = u.ResponsavelTecnicoId
                          LEFT JOIN servicocontratado s ON s.UtenteId = u.Id
                          Where u.Ativo !="+activo;
            //var resul = _context.Utente.FromSqlRaw(query).ToList();
            var result = _context.UtentesViewModel.FromSqlRaw(query).ToList();

            //var query=from utentes in _context.Utente
            //          join tecnicas in _context.Tecnico
            //          on utentes.ResponsavelTecnicoId equals tecnicas.Id into utenteTecnicas
            //          from tecnicas in utenteTecnicas.DefaultIfEmpty()
            //          join servicos in _context.ServicoContratado
            //          on utentes.OrigemContacto equals servicos.Id into utenteContrato
            //          from servicos in utenteServicos.DefaultIfEmpty()
            //          select new UtentesViewModel
            //          {
            //              Id = utentes.Id,
            //              Foto = utentes.Foto,
            //              Estado = utentes.Ativo,
            //              Nome = utentes.Nome,
            //              Tecnica = tecnicas.Nome,
            //              Servico = contrato.
            //          }


            var Utentes = _context.Utente;
            var Tecnicos = _context.Tecnico;
            var Servicos = _context.ServicoContratado;
            var viewModel = new UtentesViewModel
            {
                //Utente = Utentes.ToList(),
                //Tecnicos = Tecnicos.ToList().Where(x => x.Id == Utentes.First().ResponsavelTecnicoId).ToList(),
                //Servicos = Servicos.ToList().Where(x => x.UtenteId == Utentes.First().Id).ToList()
            };

            //var utentesViewModels = new List<UtentesViewModel>();
            //utentesViewModels.Add(viewModel);
            //IEnumerable<UtentesViewModel> listUtentes = utentesViewModels;
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

            //var morada = _context.MoradaUtente.FirstOrDefault(m => m.UtenteId == id);

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


            return View(utente);
        }

        // GET: Utentes/Create
        [Authorize]
        public IActionResult Create()
        {
            var dataResponsavelTecnico = _context.Responsavel.ToList();
            var dataFamilia = _context.FamiliaUtentes.ToList();
            var dataOrigemContacto = _context.OrigemContacto.ToList();

            ViewBag.DataResponsavel = dataResponsavelTecnico;
            ViewBag.DataFamilia = dataFamilia;
            ViewBag.DataOrigemContacto = dataOrigemContacto;

            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,IdInterno,Nome,ResponsavelTecnicoId,FamiliaId,Ativo,DataInscricao,OrigemContacto,Nif,Genero,DataNascimento,EstadoCivil,DocIdentificacaoTipo,DocIdentificacaoNum,DocIdentificacaoValidade,SegurancaSocialNum,Nacionalidade,ContactoTelemovel,ContactoEmail,Habilitacoes,Vivencia,HabitacaoTipo,HabitacaoPartilhada,NomeEmpresa,Foto")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                //string content = "Este é o conteúdo do arquivo que será baixado.";

                //byte[] bytes = Encoding.UTF8.GetBytes(content);

                // Define o tipo de conteúdo e o nome do arquivo
                //string contentType = "text/plain";
                //string fileName = "C:\\Teste\\arquivo.txt";



                var uploadsDirectoryLeitura = "C:\\Utilizador\\Diogo\\Imagens";
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


                //var a = File(bytes, contentType, filePath);

                //using (FileStream fs = File.Create(filePath))
                //{
                //    Console.WriteLine("File created successfully.");
                //}



                //File.Copy(filePath, uploadsDirectory + utente.Foto);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await file.CopyToAsync(fileStream);
                //}



                //try
                //{
                //    // Read the source file
                //    using (FileStream sourceStream = new FileStream(uploadsDirectory, FileMode.Open, FileAccess.Read))
                //    {
                //        // Create or overwrite the destination file
                //        using (FileStream destinationStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                //        {
                //            // Copy data from source to destination
                //            sourceStream.CopyTo(destinationStream);
                //        }
                //    }

                //    Console.WriteLine("File copied successfully.");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("An error occurred while copying the file: " + ex.Message);
                //}

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResponsavelId,SubSistemaId,Nif,CC,SNS,NomePrincipal,NomeApelido,DataNascimento,Nacionalidade,Genero,Telefone,Email,Morada1,CodPostal1,Localidade1,Concelho1,Morada2,Concelho2,Localidade2,CodPostal2,EstadoCivil, Ativo,TecnicoResponsavelId")] Utente utente)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            return View(utente);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utente = await _context.Utente.FindAsync(id);
            if (utente != null)
            {
                _context.Utente.Remove(utente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
