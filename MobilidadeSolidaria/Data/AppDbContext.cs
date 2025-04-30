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
            .HasOne(e => e.Usuario)
            .WithMany(u => u.Equipamentos)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        // ✅ Configuração para o Enum StatusEquipamento
        builder.Entity<Equipamento>()
            .Property(e => e.Status)
            .HasConversion(
                v => v.ToString(), // Salva como string no banco de dados
                v => (StatusEquipamento)Enum.Parse(typeof(StatusEquipamento), v)
            );

        AppDbSeed seed = new(builder);
    }
    public DbSet<MobilidadeSolidaria.Models.Categoria> Categoria { get; set; }
}