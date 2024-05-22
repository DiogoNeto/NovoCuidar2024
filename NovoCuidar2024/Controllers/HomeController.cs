using Microsoft.AspNetCore.Mvc;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using System.Diagnostics;

namespace NovoCuidar2024.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var nUtentes = _context.Utente.Where(x => x.Ativo == true).Count();
            if (nUtentes > 3 && _context.Servico.ToList()[2].Descricao != null && _context.Servico.ToList()[2].Nome != null)
            {
                Home rec = new Home
                {
                    numeroUtentes = nUtentes,
                    Utente1 = _context.Servico.ToList().FirstOrDefault().Descricao?.ToString(),
                    Servico1 = _context.Servico.ToList().FirstOrDefault().Nome?.ToString(),
                    //Preco1 = _context.Servico.ToList().FirstOrDefault().Preco.ToString(),
                    Utente2 = _context.Servico.ToList()[1].Descricao?.ToString(),
                    Servico2 = _context.Servico.ToList()[1].Nome?.ToString(),
                    //Preco2 = _context.Servico.ToList()[1].Preco.ToString(),
                    Utente3 = _context.Servico.ToList()[2].Descricao?.ToString(),
                    Servico3 = _context.Servico.ToList()[2].Nome?.ToString(),
                    //Preco3 = _context.Servico.ToList()[2].Preco.ToString(),
                };
                ViewBag.Message = rec;
            }
            else
            {
                Home rec = null;
                ViewBag.Message = rec;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
