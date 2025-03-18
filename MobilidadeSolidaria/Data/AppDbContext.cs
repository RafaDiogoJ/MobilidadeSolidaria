using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobilidadeSolidaria.Models;

namespace MobilidadeSolidaria.Data;
public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<EquipamentoFoto> EquipamentoFotos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");

        // Configuração explícita do relacionamento entre Usuario e Equipamento
            builder.Entity<Equipamento>()
                .HasOne(e => e.Usuario) // Equipamento tem um Usuario
                .WithMany(u => u.Equipamentos) // Usuario tem muitos Equipamentos
                .HasForeignKey(e => e.UsuarioId) // A chave estrangeira é UsuarioId
                .OnDelete(DeleteBehavior.Cascade); // Pode ser ajustado dependendo do comportamento desejado em caso de exclusão


        AppDbSeed seed = new(builder);
    }

}
