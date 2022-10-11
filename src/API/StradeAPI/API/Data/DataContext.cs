using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;


namespace API.Data {
    public partial class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options){
            
        }

        public virtual DbSet<Bairro> Bairros { get; set; } = null!;
        public virtual DbSet<BairroTransportadora> BairroTransportadoras { get; set; } = null!;
        public virtual DbSet<Informacao> Informacaos { get; set; } = null!;
        public virtual DbSet<Transportadora> Transportadoras { get; set; } = null!;

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
                    .HasName("PK__Bairro__4F198E84DDE68F66");

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
                    .HasName("PK__BairroTr__239077AE985D2E7F");

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

            modelBuilder.Entity<Informacao>(entity =>
            {
                entity.HasKey(e => e.IdInformacao)
                    .HasName("PK__Informac__40403D5976A461AE");

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

            modelBuilder.Entity<Transportadora>(entity =>
            {
                entity.HasKey(e => e.IdTransportadora)
                    .HasName("PK__Transpor__477CF3FC1971B51E");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }

}
