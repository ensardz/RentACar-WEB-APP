using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RentACar.Models
{
    public partial class db_RentContext : DbContext
    {
        public db_RentContext()
        {
        }

        public db_RentContext(DbContextOptions<db_RentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminPregledIznajmljena> AdminPregledIznajmljenas { get; set; }
        public virtual DbSet<Iznajmljeno> Iznajmljenos { get; set; }
        public virtual DbSet<IznamljenaVozila> IznamljenaVozilas { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Poruke> Porukes { get; set; }
        public virtual DbSet<Vozilo> Vozilos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=db_Rent;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("admin");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ime");

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sifra");
            });

            modelBuilder.Entity<AdminPregledIznajmljena>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("adminPregledIznajmljena");

                entity.Property(e => e.BrojDana).HasColumnName("brojDana");

                entity.Property(e => e.Brojvozacke)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("brojvozacke");

                entity.Property(e => e.CijenaPoDanu)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("cijenaPoDanu");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ime");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("prezime");

                entity.Property(e => e.RegOznaka)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("regOznaka");

                entity.Property(e => e.Telefon).HasColumnName("telefon");

                entity.Property(e => e.VoziloId).HasColumnName("voziloId");
            });

            modelBuilder.Entity<Iznajmljeno>(entity =>
            {
                entity.ToTable("iznajmljeno");

                entity.Property(e => e.IznajmljenoId).HasColumnName("iznajmljenoId");

                entity.Property(e => e.Brojvozacke)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("brojvozacke");

                entity.Property(e => e.Kraj)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("kraj");

                entity.Property(e => e.Pocetak)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("pocetak");

                entity.Property(e => e.VoziloId).HasColumnName("voziloId");

                entity.HasOne(d => d.BrojvozackeNavigation)
                    .WithMany(p => p.Iznajmljenos)
                    .HasForeignKey(d => d.Brojvozacke)
                    .HasConstraintName("FK__iznajmlje__brojv__70DDC3D8");

                entity.HasOne(d => d.Vozilo)
                    .WithMany(p => p.Iznajmljenos)
                    .HasForeignKey(d => d.VoziloId)
                    .HasConstraintName("FK__iznajmlje__vozil__71D1E811");
            });

            modelBuilder.Entity<IznamljenaVozila>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("iznamljenaVozila");

                entity.Property(e => e.BrojDana).HasColumnName("brojDana");

                entity.Property(e => e.CijenaPoDanu)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("cijenaPoDanu");

                entity.Property(e => e.IznajmljenoId).HasColumnName("iznajmljenoId");

                entity.Property(e => e.Kraj)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("kraj");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Pocetak)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("pocetak");

                entity.Property(e => e.RegOznaka)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("regOznaka");

                entity.Property(e => e.Slika)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("slika");

                entity.Property(e => e.VoziloId).HasColumnName("voziloId");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.Brojvozacke)
                    .HasName("PK__korisnik__96A028ABCF5D2564");

                entity.ToTable("korisnik");

                entity.Property(e => e.Brojvozacke)
                    .HasMaxLength(50)
                    .HasColumnName("brojvozacke");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adresa");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ime");

                entity.Property(e => e.KorisnikId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("korisnikId");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("prezime");

                entity.Property(e => e.Telefon).HasColumnName("telefon");
            });

            modelBuilder.Entity<Poruke>(entity =>
            {
                entity.HasKey(e => e.PorukaId)
                    .HasName("PK__poruke__1BDEB2DE2D174F37");

                entity.ToTable("poruke");

                entity.Property(e => e.PorukaId).HasColumnName("porukaId");

                entity.Property(e => e.BrVozacke)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("brVozacke");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.Poruka)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("poruka");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("prezime");
            });

            modelBuilder.Entity<Vozilo>(entity =>
            {
                entity.ToTable("vozilo");

                entity.Property(e => e.VoziloId).HasColumnName("voziloId");

                entity.Property(e => e.CijenaPoDanu)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("cijenaPoDanu");

                entity.Property(e => e.GodinaProizvodnje)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("godinaProizvodnje");

                entity.Property(e => e.Gorivo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("gorivo");

                entity.Property(e => e.Mjenjač)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("mjenjač");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Proizvođač)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("proizvođač");

                entity.Property(e => e.RegOznaka)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("regOznaka");

                entity.Property(e => e.Slika)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("slika");

                entity.Property(e => e.SnagaMotora)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("snagaMotora");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
