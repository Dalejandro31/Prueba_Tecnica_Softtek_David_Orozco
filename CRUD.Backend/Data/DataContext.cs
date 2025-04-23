using System;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Data
{
    public partial class DataContext : DbContext
    {
        // Constructor que recibe las opciones del contexto
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // DbSet representa la tabla de autores y libros en la base de datos
        public virtual DbSet<Autor> Autors { get; set; }

        public virtual DbSet<CiudadProcedencium> CiudadProcedencia { get; set; }

        public virtual DbSet<GeneroLibro> GeneroLibros { get; set; }

        public virtual DbSet<Libro> Libros { get; set; }

        public virtual DbSet<LibroGenero> LibroGeneros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=David;Database=Libros_Autores_copia;Trusted_Connection=True;TrustServerCertificate=True;");


        // Método para configurar relaciones y restricciones entre entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor).HasName("PK__Autor__DD33B031A5A7BCA3");

                entity.ToTable("Autor");

                entity.HasIndex(e => e.Correo, "UQ__Autor__60695A19D345BFC1").IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiudadProcedenciaNavigation).WithMany(p => p.Autors)
                    .HasForeignKey(d => d.IdCiudadProcedencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Autor__IdCiudadP__3A81B327");
            });

            modelBuilder.Entity<CiudadProcedencium>(entity =>
            {
                entity.HasKey(e => e.IdCiudadProcedencia).HasName("PK__CiudadPr__31C43CE03F88B686");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Pais)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroLibro>(entity =>
            {
                entity.HasKey(e => e.IdGeneroLibro).HasName("PK__GeneroLi__61089E87862552E0");

                entity.ToTable("GeneroLibro");

                entity.HasIndex(e => e.GeneroLibro1, "UQ__GeneroLi__0CAE60DE53AE81F2").IsUnique();

                entity.Property(e => e.GeneroLibro1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GeneroLibro");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro).HasName("PK__Libro__3E0B49ADE1C96BEA");

                entity.ToTable("Libro");

                entity.Property(e => e.AñoPublicacion).HasColumnType("datetime");
                entity.Property(e => e.TituloLibro)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Libro__IdAutor__3D5E1FD2");
            });

            modelBuilder.Entity<LibroGenero>(entity =>
            {
                entity.HasKey(e => e.IdLibroGenero).HasName("PK__LibroGen__E1DAB7EF2A24810B");

                entity.ToTable("LibroGenero");

                entity.HasIndex(e => new { e.IdLibro, e.IdGeneroLibro }, "UQ__LibroGen__581BC044010745B2").IsUnique();

                entity.HasOne(d => d.IdGeneroLibroNavigation).WithMany(p => p.LibroGeneros)
                    .HasForeignKey(d => d.IdGeneroLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LibroGene__IdGen__44FF419A");

                entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.LibroGeneros)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LibroGene__IdLib__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
