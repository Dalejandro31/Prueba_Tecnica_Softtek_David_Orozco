using System;
using CRUD.Backend.Data;
using CRUD.Backend.DTOs;
using CRUD.Backend.Excepciones;
using CRUD.Backend.Interfaces;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Services
{
    public class LibroService : ILibroService
    {
        private readonly DataContext _context;
        private readonly IAutorService _autorService;
        private const int MaxLibrosPermitidos = 5;

        public LibroService(DataContext context, IAutorService autorService)
        {
            _context = context;
            _autorService = autorService;
        }

        // Obtener todos los libros con su autor
        public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _context.Libros.Include(l => l.Autor).ToListAsync();
        }

        // Crear un nuevo libro
        public async Task<Libro> CrearLibroAsync(LibroDTO libroDto)
        {
            var autor = await _autorService.ObtenerPorNombreAsync(libroDto.NombreAutor);
            if (autor == null)
            {
                throw new ExcpecionAutor();
            }

            
            var cantidadLibrosDelAutor = await _context.Libros
                .CountAsync(l => l.AutorId == autor.AutorId);

            if (cantidadLibrosDelAutor >= MaxLibrosPermitidos)
            {
                throw new ExcepcionLibro();
            }

            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                AnioDeAnioPublicacion = libroDto.AnioDeAnioPublicacion ?? DateTime.MinValue,
                Genero = libroDto.Genero,
                NumeroPaginas = libroDto.NumeroPaginas ?? 0,
                AutorId = autor.AutorId
            };

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        // Modificar un libro
        public async Task<Libro> ModificarLibroAsync(int id, LibroDTO libroDto)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(l => l.LibroId == id);
            if (libro == null)
            {
                throw new ExcepcionLibro();
            }

            CRUD.Shared.Autor autor;
            if (libroDto.AutorId.HasValue)
            {
                autor = await _autorService.ObtenerPorIdAsync(libroDto.AutorId.Value);
            }
            else
            {
                autor = await _autorService.ObtenerPorNombreAsync(libroDto.NombreAutor);
            }

            if (autor == null)
            {
                throw new ExcpecionAutor();
            }

            libro.Titulo = libroDto.Titulo;
            libro.AnioDeAnioPublicacion = libroDto.AnioDeAnioPublicacion ?? DateTime.MinValue;
            libro.Genero = libroDto.Genero;
            libro.NumeroPaginas = libroDto.NumeroPaginas ?? 0;
            libro.AutorId = autor.AutorId;

            await _context.SaveChangesAsync();
            return libro;
        }
        // Eliminar libro
        public async Task<Libro> EliminarLibroAsync(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(l => l.LibroId == id);
            if (libro == null)
            {
                throw new ExcepcionLibro();
            }
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return libro;
        }
        // Obtener libro por ID
        public async Task<Libro> ObtenerPorIdAsync(int id)
        {
            return await _context.Libros.Include(l => l.Autor).FirstOrDefaultAsync(l => l.LibroId == id);
        }
    }
}
