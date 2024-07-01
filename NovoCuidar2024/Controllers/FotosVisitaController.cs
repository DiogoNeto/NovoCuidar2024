using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace NovoCuidar2024.Controllers
{
    public class FotosVisitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FotosVisitaController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: FotosVisitas
        public async Task<IActionResult> Index()
        {
            return View(await _context.FotoVisita.ToListAsync());
        }

        // GET: FotosVisitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosVisita = await _context.FotoVisita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotosVisita == null)
            {
                return NotFound();
            }

            return View(fotosVisita);
        }

        //// GET: FotosVisita/Create
        //[Authorize]
        //public IActionResult Create(int utenteId)
        //{
        //    if (utenteId == null)
        //    {
        //        return NotFound();
        //    }

        //    //FotosVisita fv = new FotosVisita() { Caminho="", Descricao="", VisitaId=1, Id= _context.FotosVisita.OrderBy(x => x.Id).LastOrDefault().Id + 1 };

        //    //string stringFileName = UploadFile(new FotosVisita { Id = _context.FotosVisita.OrderBy(x=>x.Id).LastOrDefault().Id + 1, Caminho = "", Descricao = "" });

        //    FotoViewModel fotosVisita = new FotoViewModel
        //    {
        //        Id = utenteId
        //    };
        //    return View(fotosVisita);
        //}

        // GET: FotosVisitas/Create
        //[Authorize]
        //[HttpPost]
        public IActionResult Create(FotosVisita fv)
        {


            fv.Descricao = "7591.png_1200.png";
            fv.Id = _context.Utente.OrderBy(x=>x.Id).LastOrDefault().Id+1;
            fv.VisitaId = 1;
            var uploadsDirectoryEscrita = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/");
            fv.Caminho = uploadsDirectoryEscrita;
            string stringFileName = UploadFile(fv);

            FotoVisita fotosVisita = new FotoVisita
            {
                Caminho = fv.Caminho+"/"+fv.Descricao,
                Descricao = fv.Descricao,
                VisitaId = fv.VisitaId
            };
            _context.FotoVisita.Add(fotosVisita);
            UploadFile(fv);
            _context.SaveChanges();

            
            return View(fotosVisita);
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

        private string UploadFile(FotosVisita fv)
        {
            //List<FotosVisita>? fotosVisita = _context.FotosVisita.ToList();
            string fileName = null;

            if (fv.Caminho != null)
            {
                var uploadsDirectoryLeitura = "C:\\NovoCuidar\\Fotos\\";
                var uploadsDirectoryEscrita = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var filePathLeitura = Path.Combine(uploadsDirectoryLeitura, fv.Descricao);
                var filePathEscrita = Path.Combine(uploadsDirectoryEscrita, fv.Descricao);


                System.Drawing.Image? image = null;

                try
                {
                    image = System.Drawing.Image.FromFile(filePathLeitura);
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


                //if (fotosVisita.FirstOrDefault().Caminho != null)
                //{

                //    string folderPath = @"C:\NovoCuidar\Fotos";
                //    string filePath2 = Path.Combine(folderPath, "example.txt");
                //    string filePath3 = Path.Combine(folderPath, "example.png");

                //    try
                //    {
                //        // Ensure the folder exists
                //        if (!Directory.Exists(folderPath))
                //        {
                //            Directory.CreateDirectory(folderPath);
                //        }

                //        // Create or overwrite the file at the specified path
                //        using (StreamWriter sw = new StreamWriter(filePath2))
                //        {
                //            sw.WriteLine("Hello, this is a test file.");
                //            sw.WriteLine("This file was created by a .NET application.");
                //        }

                //        string uploadDir2 = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                //        fileName = Guid.NewGuid().ToString() + "-" + fv.Caminho;

                //        //string filePath = Path.Combine(uploadDir, fileName);
                //        string filePath4 = Path.Combine(uploadDir2, fileName);


                //        Bitmap bitmap = new Bitmap(200,100);
                //        bitmap.Save(filePath4, ImageFormat.Png);

                //        Console.WriteLine("File created successfully.");
                //    }
                //    catch (UnauthorizedAccessException ex)
                //    {
                //        Console.WriteLine($"Access denied: {ex.Message}");
                //    }
                //    catch (DirectoryNotFoundException ex)
                //    {
                //        Console.WriteLine($"Directory not found: {ex.Message}");
                //    }
                //    catch (IOException ex)
                //    {
                //        Console.WriteLine($"IO error: {ex.Message}");
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                //    }


                //    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                //    fileName = Guid.NewGuid().ToString()+"-"+fotosVisita.FirstOrDefault().Caminho;

                //    //string filePath = Path.Combine(uploadDir, fileName);
                //    //string filePathEscrita = Path.Combine(uploadDir, "\\image.png");
                //    var uploadsDirectoryLeitura = "C:\\NovoCuidar\\Fotos\\";
                //    var filePathLeitura = Path.Combine(uploadsDirectoryLeitura, Guid.NewGuid() + fotosVisita.FirstOrDefault().Caminho);

                //    var uploadsDirectoryEscrita = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                //    var filePathEscrita = Path.Combine(uploadsDirectoryEscrita, fotosVisita.FirstOrDefault().Caminho);

                //    //string content = "Test";
                //    //FileStream fs = new FileStream(filePathEscrita, FileMode.Create);
                //    //byte[] buffer = new byte[1024];
                //    //fs.Write(buffer, 0, buffer.Length);

                //    System.Drawing.Image image = System.Drawing.Image.FromFile(filePathEscrita);

                //    var ms = new MemoryStream();
                //    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //    var bytess = ms.ToArray();
                //    image.Dispose();
                //    System.IO.File.WriteAllBytes(filePathEscrita, bytess);

                //    //_context.Add(fotosVisita);
                //    _context.SaveChangesAsync();

                //    ViewBag.Data = _context.Utente;

                //    //string newImagePath = Path.Combine(uploadDir);

                //    //try
                //    //{
                //    //    image.Save(newImagePath + "\\image.png", System.Drawing.Imaging.ImageFormat.Jpeg);
                //    //}
                //    //catch (Exception ex) { }



                //    //using (var fileStream = new FileStream(uploadDir, FileMode.Create))
                //    //{
                //    //    fv.Image.CopyTo(fileStream);
                //    //}
                //}
            }
            return fileName;
        }

        // POST: FotosVisitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Caminho,Descricao")] FotosVisita fotosVisita)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(fotosVisita);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(fotosVisita);
        //}

        // GET: FotosVisitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosVisita = await _context.FotoVisita.FindAsync(id);
            if (fotosVisita == null)
            {
                return NotFound();
            }
            return View(fotosVisita);
        }

        // POST: FotosVisitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Caminho,Descricao")] FotosVisita fotosVisita)
        {
            if (id != fotosVisita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotosVisita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotosVisitaExists(fotosVisita.Id))
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
            return View(fotosVisita);
        }

        // GET: FotosVisitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosVisita = await _context.FotoVisita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotosVisita == null)
            {
                return NotFound();
            }

            return View(fotosVisita);
        }

        // POST: FotosVisitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotosVisita = await _context.FotoVisita.FindAsync(id);
            if (fotosVisita != null)
            {
                _context.FotoVisita.Remove(fotosVisita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotosVisitaExists(int id)
        {
            return _context.FotoVisita.Any(e => e.Id == id);
        }
    }
}
