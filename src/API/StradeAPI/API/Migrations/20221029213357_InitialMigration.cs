using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialMigration : Migration
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
                    table.PrimaryKey("PK__Bairro__4F198E846A8FD32F", x => x.IdBairro);
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
                    table.PrimaryKey("PK__Informac__40403D592D27B42E", x => x.IdInformacao);
                });

            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    IdLoja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IdInformacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loja__38C45D6436B6D012", x => x.IdLoja);
                    table.ForeignKey(
                        name: "FK__Loja__IdInformac__3F466844",
                        column: x => x.IdInformacao,
                        principalTable: "Informacao",
                        principalColumn: "IdInformacao");
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
                    table.PrimaryKey("PK__Transpor__477CF3FCA58601D2", x => x.IdTransportadora);
                    table.ForeignKey(
                        name: "FK__Transport__IdInf__286302EC",
                        column: x => x.IdInformacao,
                        principalTable: "Informacao",
                        principalColumn: "IdInformacao");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInformacao = table.Column<int>(type: "int", nullable: true),
                    IdLoja = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__D5946642A3A237F3", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK__Cliente__IdInfor__4222D4EF",
                        column: x => x.IdInformacao,
                        principalTable: "Informacao",
                        principalColumn: "IdInformacao");
                    table.ForeignKey(
                        name: "FK__Cliente__IdLoja__4316F928",
                        column: x => x.IdLoja,
                        principalTable: "Loja",
                        principalColumn: "IdLoja");
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
                    table.PrimaryKey("PK__BairroTr__239077AE3A563C22", x => x.IdBairroTransportadora);
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

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detalhes = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdTransportadora = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pedido__9D335DC33CB9FACB", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK__Pedido__IdTransp__3C69FB99",
                        column: x => x.IdTransportadora,
                        principalTable: "Transportadora",
                        principalColumn: "IdTransportadora");
                });

            migrationBuilder.CreateTable(
                name: "TransportadoraTipoEncomenda",
                columns: table => new
                {
                    IdTransportadoraTipoEncomenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipo = table.Column<int>(type: "int", nullable: true),
                    IdTransportadora = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transpor__657B1FCE36854F03", x => x.IdTransportadoraTipoEncomenda);
                    table.ForeignKey(
                        name: "FK__Transport__IdTra__32E0915F",
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
                name: "IX_Cliente_IdInformacao",
                table: "Cliente",
                column: "IdInformacao");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdLoja",
                table: "Cliente",
                column: "IdLoja");

            migrationBuilder.CreateIndex(
                name: "IX_Loja_IdInformacao",
                table: "Loja",
                column: "IdInformacao");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdTransportadora",
                table: "Pedido",
                column: "IdTransportadora");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_IdInformacao",
                table: "Transportadora",
                column: "IdInformacao");

            migrationBuilder.CreateIndex(
                name: "IX_TransportadoraTipoEncomenda_IdTransportadora",
                table: "TransportadoraTipoEncomenda",
                column: "IdTransportadora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BairroTransportadora");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "TransportadoraTipoEncomenda");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Informacao");
        }
    }
}
