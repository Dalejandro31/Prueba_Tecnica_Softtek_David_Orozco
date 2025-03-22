using System;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Data
{
    public class DataContext : DbContext
    {
        // Constructor que recibe las opciones del contexto
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // DbSet representa la tabla de autores y libros en la base de datos
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        // Método para configurar relaciones y restricciones entre entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar la relación uno a muchos entre Autor y Libro
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
