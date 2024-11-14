using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyMi.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    CdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsNome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsEmail = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsSenha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsEndereco = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    DsAmbiente = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.CdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_aparelho",
                columns: table => new
                {
                    CdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsNomeAparelho = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsTipoAparelho = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    NrWatts = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    CdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    UsuarioCdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aparelho", x => x.CdAparelho);
                    table.ForeignKey(
                        name: "FK_tb_aparelho_tb_usuario_UsuarioCdUsuario",
                        column: x => x.UsuarioCdUsuario,
                        principalTable: "tb_usuario",
                        principalColumn: "CdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "tb_alerta",
                columns: table => new
                {
                    CdAlerta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsObservacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    StNivelPrioridade = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false),
                    DtAlerta = table.Column<DateTime>(type: "DATE", nullable: false),
                    CdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AparelhoCdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alerta", x => x.CdAlerta);
                    table.ForeignKey(
                        name: "FK_tb_alerta_tb_aparelho_AparelhoCdAparelho",
                        column: x => x.AparelhoCdAparelho,
                        principalTable: "tb_aparelho",
                        principalColumn: "CdAparelho");
                });

            migrationBuilder.CreateTable(
                name: "tb_consumo",
                columns: table => new
                {
                    CdConsumo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtConsumo = table.Column<DateTime>(type: "DATE", nullable: false),
                    NrConsumoEnergia = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    NrCusto = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    DsObservacoes = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AparelhoCdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consumo", x => x.CdConsumo);
                    table.ForeignKey(
                        name: "FK_tb_consumo_tb_aparelho_AparelhoCdAparelho",
                        column: x => x.AparelhoCdAparelho,
                        principalTable: "tb_aparelho",
                        principalColumn: "CdAparelho");
                });

            migrationBuilder.CreateTable(
                name: "tb_log_consumo",
                columns: table => new
                {
                    CdLogConsumo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtInicio = table.Column<DateTime>(type: "DATE", nullable: false),
                    DtFim = table.Column<DateTime>(type: "DATE", nullable: false),
                    NrConsumoPrevisto = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    CdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AparelhoCdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_log_consumo", x => x.CdLogConsumo);
                    table.ForeignKey(
                        name: "FK_tb_log_consumo_tb_aparelho_AparelhoCdAparelho",
                        column: x => x.AparelhoCdAparelho,
                        principalTable: "tb_aparelho",
                        principalColumn: "CdAparelho");
                });

            migrationBuilder.CreateTable(
                name: "tb_previsao_consumo",
                columns: table => new
                {
                    CdPrevisao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtPrevisao = table.Column<DateTime>(type: "DATE", nullable: false),
                    NrConsumoPrevisto = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    DsMetodoPrevisao = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    CdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AparelhoCdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_previsao_consumo", x => x.CdPrevisao);
                    table.ForeignKey(
                        name: "FK_tb_previsao_consumo_tb_aparelho_AparelhoCdAparelho",
                        column: x => x.AparelhoCdAparelho,
                        principalTable: "tb_aparelho",
                        principalColumn: "CdAparelho");
                });

            migrationBuilder.CreateTable(
                name: "tb_recomendacao",
                columns: table => new
                {
                    CdRecomendacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsObservacao = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    DtRecomendacao = table.Column<DateTime>(type: "DATE", nullable: false),
                    StRecomendacao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AparelhoCdAparelho = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_recomendacao", x => x.CdRecomendacao);
                    table.ForeignKey(
                        name: "FK_tb_recomendacao_tb_aparelho_AparelhoCdAparelho",
                        column: x => x.AparelhoCdAparelho,
                        principalTable: "tb_aparelho",
                        principalColumn: "CdAparelho");
                });

            migrationBuilder.InsertData(
                table: "tb_usuario",
                columns: new[] { "CdUsuario", "DsAmbiente", "DsEmail", "DsEndereco", "DsNome", "DsSenha" },
                values: new object[] { 1, "Ambiente padrão", "userdefault@gmail.com", "Endereco padrão", "Usuario padrão", "senha123" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_alerta_AparelhoCdAparelho",
                table: "tb_alerta",
                column: "AparelhoCdAparelho");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aparelho_UsuarioCdUsuario",
                table: "tb_aparelho",
                column: "UsuarioCdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consumo_AparelhoCdAparelho",
                table: "tb_consumo",
                column: "AparelhoCdAparelho");

            migrationBuilder.CreateIndex(
                name: "IX_tb_log_consumo_AparelhoCdAparelho",
                table: "tb_log_consumo",
                column: "AparelhoCdAparelho");

            migrationBuilder.CreateIndex(
                name: "IX_tb_previsao_consumo_AparelhoCdAparelho",
                table: "tb_previsao_consumo",
                column: "AparelhoCdAparelho");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recomendacao_AparelhoCdAparelho",
                table: "tb_recomendacao",
                column: "AparelhoCdAparelho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_alerta");

            migrationBuilder.DropTable(
                name: "tb_consumo");

            migrationBuilder.DropTable(
                name: "tb_log_consumo");

            migrationBuilder.DropTable(
                name: "tb_previsao_consumo");

            migrationBuilder.DropTable(
                name: "tb_recomendacao");

            migrationBuilder.DropTable(
                name: "tb_aparelho");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
