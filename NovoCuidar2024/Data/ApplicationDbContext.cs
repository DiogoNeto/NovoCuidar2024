using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Models;

namespace NovoCuidar2024.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NovoCuidar2024.Models.Utente> Utente { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Colaborador> Colaborador { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.SubSistema> SubSistema { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Servico> Servico { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Visita> Visita { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.ContactoPrioritario> Responsavel { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Orcamento> Orcamento { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Contrato> Contrato { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.LinhaOrcamento> LinhaOrcamento { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.MoradaUtente> MoradaUtente { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Tecnico> Tecnico { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.FamiliaUtentes> FamiliaUtentes { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.DadosClinicos> DadosClinicos { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.OrigemContacto> OrigemContacto { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Adendas> Adendas { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Cuidadora> Cuidadora { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.ServicoContratado> ServicoContratado { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.LinhaEscala> LinhaEscala { get; set; } = default!;
        public DbSet<NovoCuidar2024.ViewModel.UtentesViewModel> UtentesViewModel { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.DadosSociais> DadosSociais { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.FotoVisita> FotoVisita { get; set; } = default!;
        public DbSet<NovoCuidar2024.ViewModel.FotoViewModel> FotoViewModel { get; set; } = default!;
        public DbSet<NovoCuidar2024.ViewModel.LinhaEscalaViewModel> LinhasEscalaViewModel { get; set; } = default!;
    }
}
