using EnergyMi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EnergyMi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aparelho> Aparelhos { get; set; }
        public DbSet<LogConsumo> LogConsumos { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<PrevisaoConsumo> PrevisaoConsumos { get; set; }
        public DbSet<Recomendacao> Recomendacao { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.Usuario>().HasData(
                new Models.Usuario
                {
                    CdUsuario = 1,
                    DsNome = "Usuario padrão",
                    DsEmail = "userdefault@gmail.com",
                    DsSenha = "senha123",
                    DsEndereco = "Endereco padrão",
                    DsAmbiente = "Ambiente padrão",
                }
               );
            base.OnModelCreating(modelBuilder);
        }
    }
}
