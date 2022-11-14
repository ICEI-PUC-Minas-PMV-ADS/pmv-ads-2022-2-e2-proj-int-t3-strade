using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class CloudDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.PrimaryKey("PK__Informac__40403D5962470CF0", x => x.IdInformacao);
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
                    table.PrimaryKey("PK__Loja__38C45D6491E1114D", x => x.IdLoja);
                    table.ForeignKey(
                        name: "FK__Loja__IdInformac__33D4B598",
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
                    table.PrimaryKey("PK__Transpor__477CF3FCE932F2D8", x => x.IdTransportadora);
                    table.ForeignKey(
                        name: "FK__Transport__IdInf__267ABA7A",
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
                    table.PrimaryKey("PK__Cliente__D59466425C5DBBCC", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK__Cliente__IdInfor__36B12243",
                        column: x => x.IdInformacao,
                        principalTable: "Informacao",
                        principalColumn: "IdInformacao");
                    table.ForeignKey(
                        name: "FK__Cliente__IdLoja__37A5467C",
                        column: x => x.IdLoja,
                        principalTable: "Loja",
                        principalColumn: "IdLoja");
                });

            migrationBuilder.CreateTable(
                name: "RegiaoTransportadora",
                columns: table => new
                {
                    IdRegiaoTransportadora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRegiao = table.Column<int>(type: "int", nullable: false),
                    IdTransportadora = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RegiaoTr__E1AB131CB96DA58E", x => x.IdRegiaoTransportadora);
                    table.ForeignKey(
                        name: "FK__RegiaoTra__IdTra__29572725",
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
                    table.PrimaryKey("PK__Transpor__657B1FCE79CFFF99", x => x.IdTransportadoraTipoEncomenda);
                    table.ForeignKey(
                        name: "FK__Transport__IdTra__3E52440B",
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
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pedido__9D335DC322938805", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK__Pedido__IdClient__3B75D760",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK__Pedido__IdTransp__3A81B327",
                        column: x => x.IdTransportadora,
                        principalTable: "Transportadora",
                        principalColumn: "IdTransportadora");
                });

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
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdTransportadora",
                table: "Pedido",
                column: "IdTransportadora");

            migrationBuilder.CreateIndex(
                name: "IX_RegiaoTransportadora_IdTransportadora",
                table: "RegiaoTransportadora",
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
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "RegiaoTransportadora");

            migrationBuilder.DropTable(
                name: "TransportadoraTipoEncomenda");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "Informacao");
        }
    }
}
