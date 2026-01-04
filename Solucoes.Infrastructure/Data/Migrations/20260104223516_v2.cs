using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Solucoes.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemBacklogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBacklogStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBacklogTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBacklogTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoPapeis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoPapeis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoPorUsuarioId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_AspNetUsers_CriadoPorUsuarioId",
                        column: x => x.CriadoPorUsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoMembros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProjetoPapelId = table.Column<int>(type: "int", nullable: false),
                    EntrouEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoMembros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetoMembros_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetoMembros_ProjetoPapeis_ProjetoPapelId",
                        column: x => x.ProjetoPapelId,
                        principalTable: "ProjetoPapeis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetoMembros_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoConvites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProjetoPapelId = table.Column<int>(type: "int", nullable: false),
                    TokenHash = table.Column<byte[]>(type: "varbinary(32)", nullable: false),
                    ExpiraEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aceito = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CriadoPorProjetoMembroId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoConvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetoConvites_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetoConvites_ProjetoMembros_CriadoPorProjetoMembroId",
                        column: x => x.CriadoPorProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetoConvites_ProjetoPapeis_ProjetoPapelId",
                        column: x => x.ProjetoPapelId,
                        principalTable: "ProjetoPapeis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetoConvites_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Encerrada = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CriadoPorProjetoMembroId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprints_ProjetoMembros_CriadoPorProjetoMembroId",
                        column: x => x.CriadoPorProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sprints_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemBacklogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    SprintId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemBacklogTipoId = table.Column<int>(type: "int", nullable: false),
                    ItemBacklogStatusId = table.Column<int>(type: "int", nullable: false),
                    CriadoPorProjetoMembroId = table.Column<int>(type: "int", nullable: false),
                    ResponsavelProjetoMembroId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBacklogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBacklogs_ItemBacklogStatus_ItemBacklogStatusId",
                        column: x => x.ItemBacklogStatusId,
                        principalTable: "ItemBacklogStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogs_ItemBacklogTipos_ItemBacklogTipoId",
                        column: x => x.ItemBacklogTipoId,
                        principalTable: "ItemBacklogTipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogs_ProjetoMembros_CriadoPorProjetoMembroId",
                        column: x => x.CriadoPorProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogs_ProjetoMembros_ResponsavelProjetoMembroId",
                        column: x => x.ResponsavelProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogs_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogs_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemBacklogAnexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemBacklogId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoPorProjetoMembroId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBacklogAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBacklogAnexos_ItemBacklogs_ItemBacklogId",
                        column: x => x.ItemBacklogId,
                        principalTable: "ItemBacklogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogAnexos_ProjetoMembros_CriadoPorProjetoMembroId",
                        column: x => x.CriadoPorProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemBacklogComentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemBacklogId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoPorProjetoMembroId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBacklogComentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBacklogComentarios_ItemBacklogs_ItemBacklogId",
                        column: x => x.ItemBacklogId,
                        principalTable: "ItemBacklogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogComentarios_ProjetoMembros_CriadoPorProjetoMembroId",
                        column: x => x.CriadoPorProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemBacklogHistoricos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemBacklogId = table.Column<int>(type: "int", nullable: false),
                    ItemBacklogStatusAnteriorId = table.Column<int>(type: "int", nullable: false),
                    ItemBacklogStatusAtualId = table.Column<int>(type: "int", nullable: false),
                    AlteradoPorProjetoMembroId = table.Column<int>(type: "int", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBacklogHistoricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBacklogHistoricos_ItemBacklogStatus_ItemBacklogStatusAnteriorId",
                        column: x => x.ItemBacklogStatusAnteriorId,
                        principalTable: "ItemBacklogStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogHistoricos_ItemBacklogStatus_ItemBacklogStatusAtualId",
                        column: x => x.ItemBacklogStatusAtualId,
                        principalTable: "ItemBacklogStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogHistoricos_ItemBacklogs_ItemBacklogId",
                        column: x => x.ItemBacklogId,
                        principalTable: "ItemBacklogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemBacklogHistoricos_ProjetoMembros_AlteradoPorProjetoMembroId",
                        column: x => x.AlteradoPorProjetoMembroId,
                        principalTable: "ProjetoMembros",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ItemBacklogStatus",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[,]
                {
                    { 1, "BACKLOG", "Backlog" },
                    { 2, "EM_ANDAMENTO", "Em Andamento" },
                    { 3, "EM_REVISAO", "Em revisão" },
                    { 4, "CONCLUIDO", "Concluído" },
                    { 5, "CANCELADO", "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "ItemBacklogTipos",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[,]
                {
                    { 1, "HISTORIA_USUARIO", "História de Usuário" },
                    { 2, "TAREFA", "Tarefa" },
                    { 3, "BUG", "Bug" }
                });

            migrationBuilder.InsertData(
                table: "ProjetoPapeis",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[,]
                {
                    { 1, "PRODUCT_OWNER", "Product Owner" },
                    { 2, "SCRUM_MASTER", "Scrum Master" },
                    { 3, "DESENVOLVEDOR", "Desenvolvedor" },
                    { 4, "STAKEHOLDER", "Stakeholder" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogAnexos_CriadoPorProjetoMembroId",
                table: "ItemBacklogAnexos",
                column: "CriadoPorProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogAnexos_ItemBacklogId",
                table: "ItemBacklogAnexos",
                column: "ItemBacklogId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogComentarios_CriadoPorProjetoMembroId",
                table: "ItemBacklogComentarios",
                column: "CriadoPorProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogComentarios_ItemBacklogId",
                table: "ItemBacklogComentarios",
                column: "ItemBacklogId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogHistoricos_AlteradoPorProjetoMembroId",
                table: "ItemBacklogHistoricos",
                column: "AlteradoPorProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogHistoricos_ItemBacklogId",
                table: "ItemBacklogHistoricos",
                column: "ItemBacklogId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogHistoricos_ItemBacklogStatusAnteriorId",
                table: "ItemBacklogHistoricos",
                column: "ItemBacklogStatusAnteriorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogHistoricos_ItemBacklogStatusAtualId",
                table: "ItemBacklogHistoricos",
                column: "ItemBacklogStatusAtualId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_CriadoPorProjetoMembroId",
                table: "ItemBacklogs",
                column: "CriadoPorProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_ItemBacklogStatusId",
                table: "ItemBacklogs",
                column: "ItemBacklogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_ItemBacklogTipoId",
                table: "ItemBacklogs",
                column: "ItemBacklogTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_ProjetoId",
                table: "ItemBacklogs",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_ResponsavelProjetoMembroId",
                table: "ItemBacklogs",
                column: "ResponsavelProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_SprintId",
                table: "ItemBacklogs",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoConvites_CriadoPorProjetoMembroId",
                table: "ProjetoConvites",
                column: "CriadoPorProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoConvites_ProjetoId",
                table: "ProjetoConvites",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoConvites_ProjetoPapelId",
                table: "ProjetoConvites",
                column: "ProjetoPapelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoConvites_TokenHash",
                table: "ProjetoConvites",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoConvites_UsuarioId",
                table: "ProjetoConvites",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoMembros_ProjetoId",
                table: "ProjetoMembros",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoMembros_ProjetoPapelId",
                table: "ProjetoMembros",
                column: "ProjetoPapelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoMembros_UsuarioId",
                table: "ProjetoMembros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_CriadoPorUsuarioId",
                table: "Projetos",
                column: "CriadoPorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_CriadoPorProjetoMembroId",
                table: "Sprints",
                column: "CriadoPorProjetoMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProjetoId",
                table: "Sprints",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemBacklogAnexos");

            migrationBuilder.DropTable(
                name: "ItemBacklogComentarios");

            migrationBuilder.DropTable(
                name: "ItemBacklogHistoricos");

            migrationBuilder.DropTable(
                name: "ProjetoConvites");

            migrationBuilder.DropTable(
                name: "ItemBacklogs");

            migrationBuilder.DropTable(
                name: "ItemBacklogStatus");

            migrationBuilder.DropTable(
                name: "ItemBacklogTipos");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "ProjetoMembros");

            migrationBuilder.DropTable(
                name: "ProjetoPapeis");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
