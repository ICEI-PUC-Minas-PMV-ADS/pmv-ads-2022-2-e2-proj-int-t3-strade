﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221029213357_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Bairro", b =>
                {
                    b.Property<int>("IdBairro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBairro"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("CEP");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.HasKey("IdBairro")
                        .HasName("PK__Bairro__4F198E846A8FD32F");

                    b.ToTable("Bairro", (string)null);
                });

            modelBuilder.Entity("API.Models.BairroTransportadora", b =>
                {
                    b.Property<int>("IdBairroTransportadora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBairroTransportadora"), 1L, 1);

                    b.Property<int?>("IdBairro")
                        .HasColumnType("int");

                    b.Property<int?>("IdTransportadora")
                        .HasColumnType("int");

                    b.HasKey("IdBairroTransportadora")
                        .HasName("PK__BairroTr__239077AE3A563C22");

                    b.HasIndex("IdBairro");

                    b.HasIndex("IdTransportadora");

                    b.ToTable("BairroTransportadora", (string)null);
                });

            modelBuilder.Entity("API.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<int?>("IdInformacao")
                        .HasColumnType("int");

                    b.Property<int?>("IdLoja")
                        .HasColumnType("int");

                    b.HasKey("IdCliente")
                        .HasName("PK__Cliente__D5946642A3A237F3");

                    b.HasIndex("IdInformacao");

                    b.HasIndex("IdLoja");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("API.Models.Informacao", b =>
                {
                    b.Property<int>("IdInformacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInformacao"), 1L, 1);

                    b.Property<DateTime?>("Aniversario")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("NumeroContato")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdInformacao")
                        .HasName("PK__Informac__40403D592D27B42E");

                    b.ToTable("Informacao", (string)null);
                });

            modelBuilder.Entity("API.Models.Loja", b =>
                {
                    b.Property<int>("IdLoja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoja"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CNPJ");

                    b.Property<int?>("IdInformacao")
                        .HasColumnType("int");

                    b.HasKey("IdLoja")
                        .HasName("PK__Loja__38C45D6436B6D012");

                    b.HasIndex("IdInformacao");

                    b.ToTable("Loja", (string)null);
                });

            modelBuilder.Entity("API.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"), 1L, 1);

                    b.Property<string>("Detalhes")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdTransportadora")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdPedido")
                        .HasName("PK__Pedido__9D335DC33CB9FACB");

                    b.HasIndex("IdTransportadora");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("API.Models.Transportadora", b =>
                {
                    b.Property<int>("IdTransportadora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTransportadora"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CNPJ");

                    b.Property<int?>("IdInformacao")
                        .HasColumnType("int");

                    b.Property<int?>("MediaPreco")
                        .HasColumnType("int");

                    b.Property<int?>("NotaMediaQualidade")
                        .HasColumnType("int");

                    b.HasKey("IdTransportadora")
                        .HasName("PK__Transpor__477CF3FCA58601D2");

                    b.HasIndex("IdInformacao");

                    b.ToTable("Transportadora", (string)null);
                });

            modelBuilder.Entity("API.Models.TransportadoraTipoEncomendum", b =>
                {
                    b.Property<int>("IdTransportadoraTipoEncomenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTransportadoraTipoEncomenda"), 1L, 1);

                    b.Property<int?>("IdTipo")
                        .HasColumnType("int");

                    b.Property<int?>("IdTransportadora")
                        .HasColumnType("int");

                    b.HasKey("IdTransportadoraTipoEncomenda")
                        .HasName("PK__Transpor__657B1FCE36854F03");

                    b.HasIndex("IdTransportadora");

                    b.ToTable("TransportadoraTipoEncomenda");
                });

            modelBuilder.Entity("API.Models.BairroTransportadora", b =>
                {
                    b.HasOne("API.Models.Bairro", "IdBairroNavigation")
                        .WithMany("BairroTransportadoras")
                        .HasForeignKey("IdBairro")
                        .HasConstraintName("FK__BairroTra__IdBai__2B3F6F97");

                    b.HasOne("API.Models.Transportadora", "IdTransportadoraNavigation")
                        .WithMany("BairroTransportadoras")
                        .HasForeignKey("IdTransportadora")
                        .HasConstraintName("FK__BairroTra__IdTra__2C3393D0");

                    b.Navigation("IdBairroNavigation");

                    b.Navigation("IdTransportadoraNavigation");
                });

            modelBuilder.Entity("API.Models.Cliente", b =>
                {
                    b.HasOne("API.Models.Informacao", "IdInformacaoNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("IdInformacao")
                        .HasConstraintName("FK__Cliente__IdInfor__4222D4EF");

                    b.HasOne("API.Models.Loja", "IdLojaNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("IdLoja")
                        .HasConstraintName("FK__Cliente__IdLoja__4316F928");

                    b.Navigation("IdInformacaoNavigation");

                    b.Navigation("IdLojaNavigation");
                });

            modelBuilder.Entity("API.Models.Loja", b =>
                {
                    b.HasOne("API.Models.Informacao", "IdInformacaoNavigation")
                        .WithMany("Lojas")
                        .HasForeignKey("IdInformacao")
                        .HasConstraintName("FK__Loja__IdInformac__3F466844");

                    b.Navigation("IdInformacaoNavigation");
                });

            modelBuilder.Entity("API.Models.Pedido", b =>
                {
                    b.HasOne("API.Models.Transportadora", "IdTransportadoraNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdTransportadora")
                        .HasConstraintName("FK__Pedido__IdTransp__3C69FB99");

                    b.Navigation("IdTransportadoraNavigation");
                });

            modelBuilder.Entity("API.Models.Transportadora", b =>
                {
                    b.HasOne("API.Models.Informacao", "IdInformacaoNavigation")
                        .WithMany("Transportadoras")
                        .HasForeignKey("IdInformacao")
                        .HasConstraintName("FK__Transport__IdInf__286302EC");

                    b.Navigation("IdInformacaoNavigation");
                });

            modelBuilder.Entity("API.Models.TransportadoraTipoEncomendum", b =>
                {
                    b.HasOne("API.Models.Transportadora", "IdTransportadoraNavigation")
                        .WithMany("TransportadoraTipoEncomenda")
                        .HasForeignKey("IdTransportadora")
                        .HasConstraintName("FK__Transport__IdTra__32E0915F");

                    b.Navigation("IdTransportadoraNavigation");
                });

            modelBuilder.Entity("API.Models.Bairro", b =>
                {
                    b.Navigation("BairroTransportadoras");
                });

            modelBuilder.Entity("API.Models.Informacao", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Lojas");

                    b.Navigation("Transportadoras");
                });

            modelBuilder.Entity("API.Models.Loja", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("API.Models.Transportadora", b =>
                {
                    b.Navigation("BairroTransportadoras");

                    b.Navigation("Pedidos");

                    b.Navigation("TransportadoraTipoEncomenda");
                });
#pragma warning restore 612, 618
        }
    }
}
