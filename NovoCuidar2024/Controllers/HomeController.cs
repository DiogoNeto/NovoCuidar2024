using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Data;
using NovoCuidar2024.Models;
using System;
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
            Home rec = new Home
            {
                numeroUtentes = _context.Utente.Where(x => x.Ativo == true).Count().ToString(),
                Utente1 = _context.Servico.ToList().FirstOrDefault().Descricao.ToString(),
                Servico1 = _context.Servico.ToList().FirstOrDefault().ServicoContratado.ToString(),
                Preco1 = _context.Servico.ToList().FirstOrDefault().Preco.ToString(),
                Utente2 = _context.Servico.ToList()[1].Descricao.ToString(),
                Servico2 = _context.Servico.ToList()[1].ServicoContratado.ToString(),
                Preco2 = _context.Servico.ToList()[1].Preco.ToString(),
                Utente3 = _context.Servico.ToList()[2].Descricao.ToString(),
                Servico3 = _context.Servico.ToList()[2].ServicoContratado.ToString(),
                Preco3 = _context.Servico.ToList()[2].Preco.ToString(),
            };
        
            ViewBag.Message = rec;
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
