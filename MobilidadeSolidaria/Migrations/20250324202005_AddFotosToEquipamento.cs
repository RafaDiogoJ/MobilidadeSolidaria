using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MobilidadeSolidaria.Migrations
{
    /// <inheritdoc />
    public partial class AddFotosToEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Senha = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perfil_regra_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: true),
                    Estado = table.Column<string>(type: "longtext", nullable: true),
                    UsuarioId = table.Column<string>(type: "varchar(255)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamentos_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamentos_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_usuario_login_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_perfil",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_perfil", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_usuario_perfil_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_regra_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_usuario_token_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "item_foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    ArquivoFoto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    EquipamentoFotoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_item_foto_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_foto_item_foto_EquipamentoFotoId",
                        column: x => x.EquipamentoFotoId,
                        principalTable: "item_foto",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Foto", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Cadeiras de Rodas" },
                    { 2, null, "Andadores" },
                    { 3, null, "Bengalas e Muletas" },
                    { 4, null, "Camas e Colchões Hospitalares" },
                    { 5, null, "Bancos de Banho" },
                    { 6, null, "Aparelhos de Reabilitação" },
                    { 7, null, "Barras de Apoio" }
                });

            migrationBuilder.InsertData(
                table: "perfil",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", null, "Administrador", "ADMINISTRADOR" },
                    { "bec71b05-8f3d-4849-88bb-0e8d518d2de8", null, "Funcionário", "FUNCIONÁRIO" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", null, "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Senha", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", 0, "3787faf6-cc8f-45ac-a073-296457220964", "rafabbta@hotmail.com", true, true, null, "Rafael Diogo de Jesus", "RAFABBTA@HOTMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEB7Gv4DXsmZF7q4h2p28Zu5LiYbLu4mFmkirFpDFgiYaDohyWYpXTwGYm6NIwsNAxw==", null, false, "748efc0a-909b-44eb-8878-014214788a41", "123456", false, "admin" });

            migrationBuilder.InsertData(
                table: "Equipamentos",
                columns: new[] { "Id", "CategoriaId", "Cidade", "Descricao", "Estado", "Nome", "Status", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, "São Paulo", "Cadeira de rodas manual, estrutura leve", "SP", "Cadeira de Rodas Manual", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 2, 1, "Rio de Janeiro", "Cadeira de rodas elétrica, com controle remoto", "RJ", "Cadeira de Rodas Motorizada", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 3, 2, "Belo Horizonte", "Andador com 4 rodas e freios", "MG", "Andador com 4 Rodas", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 4, 2, "Curitiba", "Andador dobrável, ideal para transporte", "PR", "Andador Dobrável", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 5, 3, "Porto Alegre", "Muleta axilar de alumínio, ajustável", "RS", "Muleta Axilar", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 6, 3, "Salvador", "Muleta canadense com apoio de braço", "BA", "Muleta Canadense", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 7, 4, "Fortaleza", "Dispositivo de segurança usado para oferecer apoio extra para os braços do cuidador no manuseio de pacientes.", "CE", "Cinta de Manobra", 0, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 8, 4, "Recife", "Colchão de ar com sistema de pressão alternada, com sistema de massagem e estimulação de tecidos, promovendo a circulação vital", "PE", "Colchão Pneumático Dellamed", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 9, 5, "Manaus", "Estrutura em alumínio anodizado proporciona resistência à umidade e evita corrosão, enquanto seu assento ergonômico curvo com textura antiderrapante oferece maior estabilidade ao usuário.", "AM", "Banco Para Banho em Alumínio até 135KG", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 10, 5, "Belém", "Confeccionada em alumínio com encosto em Polietileno de Alta densidade - Assento Anti derrapante - Ponteira Anti Derrapante - Regulagem de altura em 6 posições - Capacidade de Peso: 110kgs", "PA", "Banco Para Banho Com Encosto/Alças", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 11, 6, "São Luís", "Mini Bicicleta Portátil Cicloergômetro Exercício Sentado para Fisioterapia Braços e Pernas", "MA", "Mini Bike Bicicleta Ergométrica", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 12, 6, "Goiânia", "Ideal para diversos exercícios de ganho de força, equilíbrio, elasticidade e condicionamento físico.", "GO", "Meia Bola Suiça Equilíbrio", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 13, 7, "Vitória", "Proporciona segurança, estabilidade e acessibilidade, auxiliando pessoas com dificuldades de locomoção ou equilíbrio. Ideal para instalação em banheiros, corredores e ambientes com risco de queda.", "ES", "Barra de Apoio em L para Banheiro", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { 14, 7, "Maceió", "Barra de Apoio Lavatório Fabricada em tubo metálico redondo de 1'' 1/4 com Acabamento: pintura eletrostática a pó. Dimensões: 60cm x 60cm", "AL", "Barra Para Lavatório", 1, "ddf093a6-6cb5-4ff7-9a64-83da34aee005" }
                });

            migrationBuilder.InsertData(
                table: "usuario_perfil",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { "bec71b05-8f3d-4849-88bb-0e8d518d2de8", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" }
                });

            migrationBuilder.InsertData(
                table: "item_foto",
                columns: new[] { "Id", "ArquivoFoto", "Descricao", "EquipamentoFotoId", "EquipamentoId" },
                values: new object[,]
                {
                    { 1, "~/images/Equipamentos/1/1.png", null, null, 1 },
                    { 2, "~/images/Equipamentos/1/2.png", null, null, 2 },
                    { 3, "~/images/Equipamentos/2/1.png", null, null, 3 },
                    { 4, "~/images/Equipamentos/2/2.png", null, null, 4 },
                    { 5, "~/images/Equipamentos/3/1.png", null, null, 5 },
                    { 6, "~/images/Equipamentos/3/2.png", null, null, 6 },
                    { 7, "~/images/Equipamentos/4/1.png", null, null, 7 },
                    { 8, "~/images/Equipamentos/4/2.png", null, null, 8 },
                    { 9, "~/images/Equipamentos/5/1.png", null, null, 9 },
                    { 10, "~/images/Equipamentos/5/2.png", null, null, 10 },
                    { 11, "~/images/Equipamentos/6/1.png", null, null, 11 },
                    { 12, "~/images/Equipamentos/6/2.png", null, null, 12 },
                    { 13, "~/images/Equipamentos/7/1.png", null, null, 13 },
                    { 14, "~/images/Equipamentos/7/2.png", null, null, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_CategoriaId",
                table: "Equipamentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_UsuarioId",
                table: "Equipamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_item_foto_EquipamentoFotoId",
                table: "item_foto",
                column: "EquipamentoFotoId");

            migrationBuilder.CreateIndex(
                name: "IX_item_foto_EquipamentoId",
                table: "item_foto",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "perfil",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perfil_regra_RoleId",
                table: "perfil_regra",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "usuario",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "usuario",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login_UserId",
                table: "usuario_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_RoleId",
                table: "usuario_perfil",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_regra_UserId",
                table: "usuario_regra",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_foto");

            migrationBuilder.DropTable(
                name: "perfil_regra");

            migrationBuilder.DropTable(
                name: "usuario_login");

            migrationBuilder.DropTable(
                name: "usuario_perfil");

            migrationBuilder.DropTable(
                name: "usuario_regra");

            migrationBuilder.DropTable(
                name: "usuario_token");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
