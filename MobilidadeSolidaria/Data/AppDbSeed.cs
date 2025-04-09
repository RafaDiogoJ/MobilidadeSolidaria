using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobilidadeSolidaria.Models;

namespace MobilidadeSolidaria.Data;

public class AppDbSeed
{
public AppDbSeed(ModelBuilder builder)
    {
        List<Categoria> categorias = new() {
            new Categoria { Id = 1, Nome = "Cadeiras de Rodas" },
            new Categoria { Id = 2, Nome = "Andadores" },
            new Categoria { Id = 3, Nome = "Bengalas e Muletas" },
            new Categoria { Id = 4, Nome = "Camas e Colchões Hospitalares" },
            new Categoria { Id = 5, Nome = "Bancos de Banho" },
            new Categoria { Id = 6, Nome = "Aparelhos de Reabilitação" },
            new Categoria { Id = 7, Nome = "Barras de Apoio" }
        };
        builder.Entity<Categoria>().HasData(categorias);

        // Definir o UsuarioId para o usuário admin
        string usuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005";

        List<Equipamento> equipamentos = new List<Equipamento>
        {
            new Equipamento { Id = 1, CategoriaId = 1, Nome = "Cadeira de Rodas Manual", Descricao = "Cadeira de rodas manual, estrutura leve", Cidade = "São Paulo", Estado = "SP", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo },
            new Equipamento { Id = 2, CategoriaId = 1, Nome = "Cadeira de Rodas Motorizada", Descricao = "Cadeira de rodas elétrica, com controle remoto", Cidade = "Rio de Janeiro", Estado = "RJ", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo  },
            new Equipamento { Id = 3, CategoriaId = 2, Nome = "Andador com 4 Rodas", Descricao = "Andador com 4 rodas e freios", Cidade = "Belo Horizonte", Estado = "MG", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo },
            new Equipamento { Id = 4, CategoriaId = 2, Nome = "Andador Dobrável", Descricao = "Andador dobrável, ideal para transporte", Cidade = "Curitiba", Estado = "PR", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo },
            new Equipamento { Id = 5, CategoriaId = 3, Nome = "Muleta Axilar", Descricao = "Muleta axilar de alumínio, ajustável", Cidade = "Porto Alegre", Estado = "RS", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo },
            new Equipamento { Id = 6, CategoriaId = 3, Nome = "Muleta Canadense", Descricao = "Muleta canadense com apoio de braço", Cidade = "Salvador", Estado = "BA", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo },
            new Equipamento { Id = 7, CategoriaId = 4, Nome = "Cinta de Manobra", Descricao = "Dispositivo de segurança usado para oferecer apoio extra para os braços do cuidador no manuseio de pacientes.", Cidade = "Fortaleza", Estado = "CE", UsuarioId = usuarioId, Status = StatusEquipamento.Emprestimo },
            new Equipamento { Id = 8, CategoriaId = 4, Nome = "Colchão Pneumático Dellamed", Descricao = "Colchão de ar com sistema de pressão alternada, com sistema de massagem e estimulação de tecidos, promovendo a circulação vital", Cidade = "Recife", Estado = "PE", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao },
            new Equipamento { Id = 9, CategoriaId = 5, Nome = "Banco Para Banho em Alumínio até 135KG", Descricao = "Estrutura em alumínio anodizado proporciona resistência à umidade e evita corrosão, enquanto seu assento ergonômico curvo com textura antiderrapante oferece maior estabilidade ao usuário.", Cidade = "Manaus", Estado = "AM", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao },
            new Equipamento { Id = 10, CategoriaId = 5, Nome = "Banco Para Banho Com Encosto/Alças", Descricao = "Confeccionada em alumínio com encosto em Polietileno de Alta densidade - Assento Anti derrapante - Ponteira Anti Derrapante - Regulagem de altura em 6 posições - Capacidade de Peso: 110kgs", Cidade = "Belém", Estado = "PA", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao },
            new Equipamento { Id = 11, CategoriaId = 6, Nome = "Mini Bike Bicicleta Ergométrica", Descricao = "Mini Bicicleta Portátil Cicloergômetro Exercício Sentado para Fisioterapia Braços e Pernas", Cidade = "São Luís", Estado = "MA", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao },
            new Equipamento { Id = 12, CategoriaId = 6, Nome = "Meia Bola Suiça Equilíbrio", Descricao = "Ideal para diversos exercícios de ganho de força, equilíbrio, elasticidade e condicionamento físico.", Cidade = "Goiânia", Estado = "GO", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao },
            new Equipamento { Id = 13, CategoriaId = 7, Nome = "Barra de Apoio em L para Banheiro", Descricao = "Proporciona segurança, estabilidade e acessibilidade, auxiliando pessoas com dificuldades de locomoção ou equilíbrio. Ideal para instalação em banheiros, corredores e ambientes com risco de queda.", Cidade = "Vitória", Estado = "ES", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao },
            new Equipamento { Id = 14, CategoriaId = 7, Nome = "Barra Para Lavatório", Descricao = "Barra de Apoio Lavatório Fabricada em tubo metálico redondo de 1'' 1/4 com Acabamento: pintura eletrostática a pó. Dimensões: 60cm x 60cm", Cidade = "Maceió", Estado = "AL", UsuarioId = usuarioId, Status = StatusEquipamento.Doacao }
        };
        builder.Entity<Equipamento>().HasData(equipamentos);

        List<EquipamentoFoto> equipamentoFotos = new List<EquipamentoFoto>
        {
            new EquipamentoFoto { Id = 1, EquipamentoId = 1, ArquivoFoto = "~/images/Equipamentos/1/1.png" },
            new EquipamentoFoto { Id = 2, EquipamentoId = 2, ArquivoFoto = "~/images/Equipamentos/1/2.png" },
            new EquipamentoFoto { Id = 3, EquipamentoId = 3, ArquivoFoto = "~/images/Equipamentos/2/1.png" },
            new EquipamentoFoto { Id = 4, EquipamentoId = 4, ArquivoFoto = "~/images/Equipamentos/2/2.png" },
            new EquipamentoFoto { Id = 5, EquipamentoId = 5, ArquivoFoto = "~/images/Equipamentos/3/1.png" },
            new EquipamentoFoto { Id = 6, EquipamentoId = 6, ArquivoFoto = "~/images/Equipamentos/3/2.png" },
            new EquipamentoFoto { Id = 7, EquipamentoId = 7, ArquivoFoto = "~/images/Equipamentos/4/1.png" },
            new EquipamentoFoto { Id = 8, EquipamentoId = 8, ArquivoFoto = "~/images/Equipamentos/4/2.png" },
            new EquipamentoFoto { Id = 9, EquipamentoId = 9, ArquivoFoto = "~/images/Equipamentos/5/1.png" },
            new EquipamentoFoto { Id = 10, EquipamentoId = 10, ArquivoFoto = "~/images/Equipamentos/5/2.png" },
            new EquipamentoFoto { Id = 11, EquipamentoId = 11, ArquivoFoto = "~/images/Equipamentos/6/1.png" },
            new EquipamentoFoto { Id = 12, EquipamentoId = 12, ArquivoFoto = "~/images/Equipamentos/6/2.png" },
            new EquipamentoFoto { Id = 13, EquipamentoId = 13, ArquivoFoto = "~/images/Equipamentos/7/1.png" },
            new EquipamentoFoto { Id = 14, EquipamentoId = 14, ArquivoFoto = "~/images/Equipamentos/7/2.png" }
        };
        builder.Entity<EquipamentoFoto>().HasData(equipamentoFotos);

        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "bec71b05-8f3d-4849-88bb-0e8d518d2de8",
               Name = "Funcionário",
               NormalizedName = "FUNCIONÁRIO"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new() {
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "rafabbta@hotmail.com",
                NormalizedEmail = "RAFABBTA@HOTMAIL.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Rafael Diogo de Jesus",
                DataNascimento = DateTime.Parse("27/12/1999")
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}