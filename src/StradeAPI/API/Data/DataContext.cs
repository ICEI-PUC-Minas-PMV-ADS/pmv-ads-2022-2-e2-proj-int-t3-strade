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

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Informacao> Informacaos { get; set; } = null!;
        public virtual DbSet<Loja> Lojas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<RegiaoTransportadora> RegiaoTransportadoras { get; set; } = null!;
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
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466425C5DBBCC");

                entity.ToTable("Cliente");

                entity.HasOne(d => d.IdInformacaoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdInformacao)
                    .HasConstraintName("FK__Cliente__IdInfor__36B12243");

                entity.HasOne(d => d.IdLojaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdLoja)
                    .HasConstraintName("FK__Cliente__IdLoja__37A5467C");
            });

            modelBuilder.Entity<Informacao>(entity =>
            {
                entity.HasKey(e => e.IdInformacao)
                    .HasName("PK__Informac__40403D5962470CF0");

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
                    .HasName("PK__Loja__38C45D6491E1114D");

                entity.ToTable("Loja");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.HasOne(d => d.IdInformacaoNavigation)
                    .WithMany(p => p.Lojas)
                    .HasForeignKey(d => d.IdInformacao)
                    .HasConstraintName("FK__Loja__IdInformac__33D4B598");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__9D335DC322938805");

                entity.ToTable("Pedido");

                entity.Property(e => e.Detalhes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Pedido__IdClient__3B75D760");

                entity.HasOne(d => d.IdTransportadoraNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdTransportadora)
                    .HasConstraintName("FK__Pedido__IdTransp__3A81B327");
            });

            modelBuilder.Entity<RegiaoTransportadora>(entity =>
            {
                entity.HasKey(e => e.IdRegiaoTransportadora)
                    .HasName("PK__RegiaoTr__E1AB131CB96DA58E");

                entity.ToTable("RegiaoTransportadora");

                entity.HasOne(d => d.IdTransportadoraNavigation)
                    .WithMany(p => p.RegiaoTransportadoras)
                    .HasForeignKey(d => d.IdTransportadora)
                    .HasConstraintName("FK__RegiaoTra__IdTra__29572725");
            });

            modelBuilder.Entity<Transportadora>(entity =>
            {
                entity.HasKey(e => e.IdTransportadora)
                    .HasName("PK__Transpor__477CF3FCE932F2D8");

                entity.ToTable("Transportadora");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.HasOne(d => d.IdInformacaoNavigation)
                    .WithMany(p => p.Transportadoras)
                    .HasForeignKey(d => d.IdInformacao)
                    .HasConstraintName("FK__Transport__IdInf__267ABA7A");
            });

            modelBuilder.Entity<TransportadoraTipoEncomendum>(entity =>
            {
                entity.HasKey(e => e.IdTransportadoraTipoEncomenda)
                    .HasName("PK__Transpor__657B1FCE79CFFF99");

                entity.HasOne(d => d.IdTransportadoraNavigation)
                    .WithMany(p => p.TransportadoraTipoEncomenda)
                    .HasForeignKey(d => d.IdTransportadora)
                    .HasConstraintName("FK__Transport__IdTra__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
        
}