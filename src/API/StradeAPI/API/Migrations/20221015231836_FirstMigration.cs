using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bairro",
                columns: table => new
                {
                    IdBairro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    CEP = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bairro__4F198E84DDE68F66", x => x.IdBairro);
                });

            migrationBuilder.CreateTable(
                name: "Informacao",
                columns: table => new
                {
                    IdInformacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Aniversario = table.Column<DateTime>(type: "datetime", nullable: true),
                    NumeroContato = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Informac__40403D5976A461AE", x => x.IdInformacao);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    IdTransportadora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NotaMediaQualidade = table.Column<int>(type: "int", nullable: true),
                    MediaPreco = table.Column<int>(type: "int", nullable: true),
                    IdInformacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transpor__477CF3FC1971B51E", x => x.IdTransportadora);
                    table.ForeignKey(
                        name: "FK__Transport__IdInf__286302EC",
                        column: x => x.IdInformacao,
                        principalTable: "Informacao",
                        principalColumn: "IdInformacao");
                });

            migrationBuilder.CreateTable(
                name: "BairroTransportadora",
                columns: table => new
                {
                    IdBairroTransportadora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBairro = table.Column<int>(type: "int", nullable: true),
                    IdTransportadora = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BairroTr__239077AE985D2E7F", x => x.IdBairroTransportadora);
                    table.ForeignKey(
                        name: "FK__BairroTra__IdBai__2B3F6F97",
                        column: x => x.IdBairro,
                        principalTable: "Bairro",
                        principalColumn: "IdBairro");
                    table.ForeignKey(
                        name: "FK__BairroTra__IdTra__2C3393D0",
                        column: x => x.IdTransportadora,
                        principalTable: "Transportadora",
                        principalColumn: "IdTransportadora");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BairroTransportadora_IdBairro",
                table: "BairroTransportadora",
                column: "IdBairro");

            migrationBuilder.CreateIndex(
                name: "IX_BairroTransportadora_IdTransportadora",
                table: "BairroTransportadora",
                column: "IdTransportadora");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_IdInformacao",
                table: "Transportadora",
                column: "IdInformacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BairroTransportadora");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Informacao");
        }
    }
}
