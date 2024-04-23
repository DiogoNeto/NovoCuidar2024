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
        public DbSet<NovoCuidar2024.Models.Responsavel> Responsavel { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Orcamento> Orcamento { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.Contrato> Contrato { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.LinhaOrcamento> LinhaOrcamento { get; set; } = default!;
        public DbSet<NovoCuidar2024.Models.MoradaUtente> MoradaUtente { get; set; } = default!;
    }
}
