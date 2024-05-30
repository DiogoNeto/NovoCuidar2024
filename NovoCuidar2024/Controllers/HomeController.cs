using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Index()
        {
            var nUtentes = _context.Utente.Where(x => x.Ativo == true).Count();
            if (nUtentes > 3)
            {
                Home rec = new Home
                {
                    numeroUtentes = nUtentes,

                    Utente1 = _context.ServicoContratado.ToList().FirstOrDefault().UtenteId.ToString(),
                    Servico1 = _context.ServicoContratado.ToList().FirstOrDefault().Descricao?.ToString(),
                    Periodicidade1 = _context.ServicoContratado.ToList()[0].Periodicidade?.ToString(),
                    DataInicio1 = _context.ServicoContratado.ToList()[0].DataInicio.ToString(),
                    Utente2 = _context.ServicoContratado.ToList()[1].UtenteId.ToString(),
                    Servico2 = _context.ServicoContratado.ToList()[1].Descricao.ToString(),
                    Periodicidade2 = _context.ServicoContratado.ToList()[1].Periodicidade.ToString(),
                    DataInicio2 = _context.ServicoContratado.ToList()[1].DataInicio.ToString(),
                    Utente3 = _context.ServicoContratado.ToList()[2].UtenteId.ToString(),
                    Servico3 = _context.ServicoContratado.ToList()[2].Descricao?.ToString(),
                    Periodicidade3 = _context.ServicoContratado.ToList()[2].Periodicidade?.ToString(),
                    DataInicio3 = _context.ServicoContratado.ToList()[2].DataInicio.ToString()
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
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Authorize]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
