﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobilidadeSolidaria.Data;

#nullable disable

namespace MobilidadeSolidaria.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250328173611_CriarUsuario")]
    partial class CriarUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("perfil", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "bec71b05-8f3d-4849-88bb-0e8d518d2de8",
                            Name = "Funcionário",
                            NormalizedName = "FUNCIONÁRIO"
                        },
                        new
                        {
                            Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                            Name = "Cliente",
                            NormalizedName = "CLIENTE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("perfil_regra", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("usuario_regra", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("usuario_login", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("usuario_perfil", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                            RoleId = "0b44ca04-f6b0-4a8f-a953-1f2330d30894"
                        },
                        new
                        {
                            UserId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                            RoleId = "bec71b05-8f3d-4849-88bb-0e8d518d2de8"
                        },
                        new
                        {
                            UserId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                            RoleId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("usuario_token", (string)null);
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("categoria");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Cadeiras de Rodas"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Andadores"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Bengalas e Muletas"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Camas e Colchões Hospitalares"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Bancos de Banho"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Aparelhos de Reabilitação"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Barras de Apoio"
                        });
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Equipamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            Cidade = "São Paulo",
                            Descricao = "Cadeira de rodas manual, estrutura leve",
                            Estado = "SP",
                            Nome = "Cadeira de Rodas Manual",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 1,
                            Cidade = "Rio de Janeiro",
                            Descricao = "Cadeira de rodas elétrica, com controle remoto",
                            Estado = "RJ",
                            Nome = "Cadeira de Rodas Motorizada",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 3,
                            CategoriaId = 2,
                            Cidade = "Belo Horizonte",
                            Descricao = "Andador com 4 rodas e freios",
                            Estado = "MG",
                            Nome = "Andador com 4 Rodas",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 4,
                            CategoriaId = 2,
                            Cidade = "Curitiba",
                            Descricao = "Andador dobrável, ideal para transporte",
                            Estado = "PR",
                            Nome = "Andador Dobrável",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 5,
                            CategoriaId = 3,
                            Cidade = "Porto Alegre",
                            Descricao = "Muleta axilar de alumínio, ajustável",
                            Estado = "RS",
                            Nome = "Muleta Axilar",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 6,
                            CategoriaId = 3,
                            Cidade = "Salvador",
                            Descricao = "Muleta canadense com apoio de braço",
                            Estado = "BA",
                            Nome = "Muleta Canadense",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 7,
                            CategoriaId = 4,
                            Cidade = "Fortaleza",
                            Descricao = "Dispositivo de segurança usado para oferecer apoio extra para os braços do cuidador no manuseio de pacientes.",
                            Estado = "CE",
                            Nome = "Cinta de Manobra",
                            Status = "Emprestimo",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 8,
                            CategoriaId = 4,
                            Cidade = "Recife",
                            Descricao = "Colchão de ar com sistema de pressão alternada, com sistema de massagem e estimulação de tecidos, promovendo a circulação vital",
                            Estado = "PE",
                            Nome = "Colchão Pneumático Dellamed",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 9,
                            CategoriaId = 5,
                            Cidade = "Manaus",
                            Descricao = "Estrutura em alumínio anodizado proporciona resistência à umidade e evita corrosão, enquanto seu assento ergonômico curvo com textura antiderrapante oferece maior estabilidade ao usuário.",
                            Estado = "AM",
                            Nome = "Banco Para Banho em Alumínio até 135KG",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 10,
                            CategoriaId = 5,
                            Cidade = "Belém",
                            Descricao = "Confeccionada em alumínio com encosto em Polietileno de Alta densidade - Assento Anti derrapante - Ponteira Anti Derrapante - Regulagem de altura em 6 posições - Capacidade de Peso: 110kgs",
                            Estado = "PA",
                            Nome = "Banco Para Banho Com Encosto/Alças",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 11,
                            CategoriaId = 6,
                            Cidade = "São Luís",
                            Descricao = "Mini Bicicleta Portátil Cicloergômetro Exercício Sentado para Fisioterapia Braços e Pernas",
                            Estado = "MA",
                            Nome = "Mini Bike Bicicleta Ergométrica",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 12,
                            CategoriaId = 6,
                            Cidade = "Goiânia",
                            Descricao = "Ideal para diversos exercícios de ganho de força, equilíbrio, elasticidade e condicionamento físico.",
                            Estado = "GO",
                            Nome = "Meia Bola Suiça Equilíbrio",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 13,
                            CategoriaId = 7,
                            Cidade = "Vitória",
                            Descricao = "Proporciona segurança, estabilidade e acessibilidade, auxiliando pessoas com dificuldades de locomoção ou equilíbrio. Ideal para instalação em banheiros, corredores e ambientes com risco de queda.",
                            Estado = "ES",
                            Nome = "Barra de Apoio em L para Banheiro",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        },
                        new
                        {
                            Id = 14,
                            CategoriaId = 7,
                            Cidade = "Maceió",
                            Descricao = "Barra de Apoio Lavatório Fabricada em tubo metálico redondo de 1'' 1/4 com Acabamento: pintura eletrostática a pó. Dimensões: 60cm x 60cm",
                            Estado = "AL",
                            Nome = "Barra Para Lavatório",
                            Status = "Doacao",
                            UsuarioId = "ddf093a6-6cb5-4ff7-9a64-83da34aee005"
                        });
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.EquipamentoFoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArquivoFoto")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("EquipamentoFotoId")
                        .HasColumnType("int");

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentoFotoId");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("item_foto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArquivoFoto = "~/images/Equipamentos/1/1.png",
                            EquipamentoId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArquivoFoto = "~/images/Equipamentos/1/2.png",
                            EquipamentoId = 2
                        },
                        new
                        {
                            Id = 3,
                            ArquivoFoto = "~/images/Equipamentos/2/1.png",
                            EquipamentoId = 3
                        },
                        new
                        {
                            Id = 4,
                            ArquivoFoto = "~/images/Equipamentos/2/2.png",
                            EquipamentoId = 4
                        },
                        new
                        {
                            Id = 5,
                            ArquivoFoto = "~/images/Equipamentos/3/1.png",
                            EquipamentoId = 5
                        },
                        new
                        {
                            Id = 6,
                            ArquivoFoto = "~/images/Equipamentos/3/2.png",
                            EquipamentoId = 6
                        },
                        new
                        {
                            Id = 7,
                            ArquivoFoto = "~/images/Equipamentos/4/1.png",
                            EquipamentoId = 7
                        },
                        new
                        {
                            Id = 8,
                            ArquivoFoto = "~/images/Equipamentos/4/2.png",
                            EquipamentoId = 8
                        },
                        new
                        {
                            Id = 9,
                            ArquivoFoto = "~/images/Equipamentos/5/1.png",
                            EquipamentoId = 9
                        },
                        new
                        {
                            Id = 10,
                            ArquivoFoto = "~/images/Equipamentos/5/2.png",
                            EquipamentoId = 10
                        },
                        new
                        {
                            Id = 11,
                            ArquivoFoto = "~/images/Equipamentos/6/1.png",
                            EquipamentoId = 11
                        },
                        new
                        {
                            Id = 12,
                            ArquivoFoto = "~/images/Equipamentos/6/2.png",
                            EquipamentoId = 12
                        },
                        new
                        {
                            Id = 13,
                            ArquivoFoto = "~/images/Equipamentos/7/1.png",
                            EquipamentoId = 13
                        },
                        new
                        {
                            Id = 14,
                            ArquivoFoto = "~/images/Equipamentos/7/2.png",
                            EquipamentoId = 14
                        });
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("usuario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c8d5a45-0cb8-474b-a1b8-588828a840e3",
                            Email = "rafabbta@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            Nome = "Rafael Diogo de Jesus",
                            NormalizedEmail = "RAFABBTA@HOTMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEAnDAK0G4SUMXcOhpqe5Rjsl0nkE7/eFJXtBIchqnT+7isfCgbdDid6BYm8eCTk2LQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4b0fa609-7afa-4026-8c61-cba85da694b4",
                            Senha = "123456",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MobilidadeSolidaria.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MobilidadeSolidaria.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobilidadeSolidaria.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MobilidadeSolidaria.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.Equipamento", b =>
                {
                    b.HasOne("MobilidadeSolidaria.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobilidadeSolidaria.Models.Usuario", "Usuario")
                        .WithMany("Equipamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.EquipamentoFoto", b =>
                {
                    b.HasOne("MobilidadeSolidaria.Models.EquipamentoFoto", null)
                        .WithMany("Fotos")
                        .HasForeignKey("EquipamentoFotoId");

                    b.HasOne("MobilidadeSolidaria.Models.Equipamento", "Equipamento")
                        .WithMany("Fotos")
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.Equipamento", b =>
                {
                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.EquipamentoFoto", b =>
                {
                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("MobilidadeSolidaria.Models.Usuario", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
