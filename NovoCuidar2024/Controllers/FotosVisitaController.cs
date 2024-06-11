using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;
using System.Drawing;

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
            return View(await _context.FotosVisita.ToListAsync());
        }

        // GET: FotosVisitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosVisita = await _context.FotosVisita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotosVisita == null)
            {
                return NotFound();
            }

            return View(fotosVisita);
        }

        // GET: FotosVisita/Create
        [Authorize]
        public IActionResult Create(int utenteId)
        {
            if (utenteId == null)
            {
                return NotFound();
            }
            FotoViewModel fotosVisita = new FotoViewModel
            {
                Id = utenteId
            };
            return View(fotosVisita);
        }

        // GET: FotosVisitas/Create
        [Authorize]
        [HttpPost]
        public IActionResult Create(FotoViewModel fv)
        {
            string stringFileName = UploadFile(fv);
             
            FotosVisita fotosVisita = new FotosVisita
            {
                Caminho = fv.Name,
                Descricao = "",
            };
            _context.FotosVisita.Add(fotosVisita);
            _context.SaveChanges();
            return View(fotosVisita);
        }

        private string UploadFile(FotoViewModel fv)
        {
            string fileName = null;
            if (fv.Name != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString()+"-"+fv.Name;

                //string filePath = Path.Combine(uploadDir, fileName);
                string filePath = Path.Combine(uploadDir, "\\image.png");
                string content = "Test";
                FileStream fs = new FileStream(uploadDir, FileMode.Create);
                byte[] buffer = new byte[1024];
                fs.Write(buffer, 0, buffer.Length);

                Image img = Image.FromFile(uploadDir + filePath);
                string newImagePath = Path.Combine(uploadDir);
                img.Save(newImagePath+"\\image.png", System.Drawing.Imaging.ImageFormat.Jpeg);
                using (var fileStream = new FileStream(uploadDir, FileMode.Create))
                {
                    fv.Image.CopyTo(fileStream);
                }
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

            var fotosVisita = await _context.FotosVisita.FindAsync(id);
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

            var fotosVisita = await _context.FotosVisita
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
            var fotosVisita = await _context.FotosVisita.FindAsync(id);
            if (fotosVisita != null)
            {
                _context.FotosVisita.Remove(fotosVisita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotosVisitaExists(int id)
        {
            return _context.FotosVisita.Any(e => e.Id == id);
        }
    }
}
