//using API.Models;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data {
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bairro> Bairros { get; set; } = null!;
        public virtual DbSet<BairroTransportadora> BairroTransportadoras { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Informacao> Informacaos { get; set; } = null!;
        public virtual DbSet<Loja> Lojas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Transportadora> Transportadoras { get; set; } = null!;
        public virtual DbSet<TransportadoraTipoEncomendum> TransportadoraTipoEncomenda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=STRADE;Persist Security info=True;Trusted_Connection=True;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.HasKey(e => e.IdBairro)
                    .HasName("PK__Bairro__4F198E846A8FD32F");

                entity.ToTable("Bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BairroTransportadora>(entity =>
            {
                entity.HasKey(e => e.IdBairroTransportadora)
                    .HasName("PK__BairroTr__239077AE3A563C22");

                entity.ToTable("BairroTransportadora");

                entity.HasOne(d => d.IdBairroNavigation)
                    .WithMany(p => p.BairroTransportadoras)
                    .HasForeignKey(d => d.IdBairro)
                    .HasConstraintName("FK__BairroTra__IdBai__2B3F6F97");

                entity.HasOne(d => d.IdTransportadoraNavigation)
                    .WithMany(p => p.BairroTransportadoras)
                    .HasForeignKey(d => d.IdTransportadora)
                    .HasConstraintName("FK__BairroTra__IdTra__2C3393D0");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642A3A237F3");

                entity.ToTable("Cliente");

                entity.HasOne(d => d.IdInformacaoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdInformacao)
                    .HasConstraintName("FK__Cliente__IdInfor__4222D4EF");

                entity.HasOne(d => d.IdLojaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdLoja)
                    .HasConstraintName("FK__Cliente__IdLoja__4316F928");
            });

            modelBuilder.Entity<Informacao>(entity =>
            {
                entity.HasKey(e => e.IdInformacao)
                    .HasName("PK__Informac__40403D592D27B42E");

                entity.ToTable("Informacao");

                entity.Property(e => e.Aniversario).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroContato)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loja>(entity =>
            {
                entity.HasKey(e => e.IdLoja)
                    .HasName("PK__Loja__38C45D6436B6D012");

                entity.ToTable("Loja");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.HasOne(d => d.IdInformacaoNavigation)
                    .WithMany(p => p.Lojas)
                    .HasForeignKey(d => d.IdInformacao)
                    .HasConstraintName("FK__Loja__IdInformac__3F466844");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__9D335DC33CB9FACB");

                entity.ToTable("Pedido");

                entity.Property(e => e.Detalhes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTransportadoraNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdTransportadora)
                    .HasConstraintName("FK__Pedido__IdTransp__3C69FB99");
            });

            modelBuilder.Entity<Transportadora>(entity =>
            {
                entity.HasKey(e => e.IdTransportadora)
                    .HasName("PK__Transpor__477CF3FCA58601D2");

                entity.ToTable("Transportadora");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.HasOne(d => d.IdInformacaoNavigation)
                    .WithMany(p => p.Transportadoras)
                    .HasForeignKey(d => d.IdInformacao)
                    .HasConstraintName("FK__Transport__IdInf__286302EC");
            });

            modelBuilder.Entity<TransportadoraTipoEncomendum>(entity =>
            {
                entity.HasKey(e => e.IdTransportadoraTipoEncomenda)
                    .HasName("PK__Transpor__657B1FCE36854F03");

                entity.HasOne(d => d.IdTransportadoraNavigation)
                    .WithMany(p => p.TransportadoraTipoEncomenda)
                    .HasForeignKey(d => d.IdTransportadora)
                    .HasConstraintName("FK__Transport__IdTra__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
        
}
