using System;
using System.Data;
using CRUD.Backend.Data;
using CRUD.Backend.DTOs;
using CRUD.Backend.Excepciones;
using CRUD.Backend.Interfaces;
using CRUD.Backend.InterfacesRepository;
using CRUD.Shared;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Services
{
    public class LibroService : ILibroService
    {
        private readonly DataContext _context;
        private readonly ILibroRepository _libroRepository;
        private readonly IAutorService _autorService;
        private const int MaxLibrosPermitidos = 5;

        public LibroService(IAutorService autorService, ILibroRepository libroRepository, DataContext context)
        {
            _context = context;
            _autorService = autorService;
            _libroRepository = libroRepository;
        }

        // Obtener todos los libros con su autor
        public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            //return await _context.Libros
            //    .Include(l => l.IdAutorNavigation)
            //    .Include(l => l.LibroGeneros)
            //    .ThenInclude(lg => lg.IdGeneroLibroNavigation)
            //.ToListAsync();
            return await _libroRepository.ObtenerTodosAsync();
        }

        // Crear un nuevo libro
        public async Task<Libro> CrearLibroAsync(LibroDTO libroDto)
        {
            //var autor = await _autorService.ObtenerPorNombreAsync(libroDto.NombreAutor);
            //if (autor == null)
            //{
            //    throw new ExcpecionAutor();
            //}


            //var cantidadLibrosDelAutor = await _context.Libros
            //    .CountAsync(l => l.IdAutor == autor.IdAutor);

            //if (cantidadLibrosDelAutor >= MaxLibrosPermitidos)
            //{
            //    throw new ExcepcionLibro();
            //}

            //var libro = new Libro
            //{
            //    TituloLibro= libroDto.TituloLibro,
            //    AñoPublicacion = libroDto.AñoPublicacion,
            //    NumeroDePaginas = libroDto.NumeroDePaginas,
            //    IdAutor = autor.IdAutor
            //};

            //_context.Libros.Add(libro);
            //await _context.SaveChangesAsync();

            //foreach (var idGenero in libroDto.GenerosSeleccionados)
            //{
            //    _context.LibroGeneros.Add(new LibroGenero
            //    {
            //        IdLibro = libro.IdLibro,
            //        IdGeneroLibro = idGenero
            //    });
            //}

            //await _context.SaveChangesAsync();
            //return libro;
            var autor = await _autorService.ObtenerPorNombreAsync(libroDto.NombreAutor);
            if (autor == null)
                throw new ExcpecionAutor();

            var cantidadLibros = (await _libroRepository.ObtenerTodosAsync())
                .Count(l => l.IdAutor == autor.IdAutor);

            if (cantidadLibros >= MaxLibrosPermitidos)
                throw new ExcepcionLibro();

            var libro = new Libro
            {
                TituloLibro = libroDto.TituloLibro,
                AñoPublicacion = libroDto.AñoPublicacion,
                NumeroDePaginas = libroDto.NumeroDePaginas,
                IdAutor = autor.IdAutor
            };

            await _libroRepository.CrearAsync(libro);

            foreach (var idGenero in libroDto.GenerosSeleccionados)
            {
                _context.LibroGeneros.Add(new LibroGenero
                {
                    IdLibro = libro.IdLibro,
                    IdGeneroLibro = idGenero
                });
            }

            await _context.SaveChangesAsync();
            return libro;
        }

        // Modificar un libro
        public async Task<Libro> ModificarLibroAsync(int id, LibroDTO libroDto)
        {
            //var libro = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == id);
            //if (libro == null)
            //{
            //    throw new ExcepcionLibro();
            //}

            //CRUD.Shared.Autor autor;
            //if (libroDto.AutorId.HasValue)
            //{
            //    autor = await _autorService.ObtenerPorIdAsync(libroDto.AutorId.Value);
            //}
            //else
            //{
            //    autor = await _autorService.ObtenerPorNombreAsync(libroDto.NombreAutor);
            //}

            //if (autor == null)
            //{
            //    throw new ExcpecionAutor();
            //}

            //libro.TituloLibro = libroDto.TituloLibro;
            //libro.AñoPublicacion = libroDto.AñoPublicacion;
            //libro.NumeroDePaginas = libroDto.NumeroDePaginas;
            //libro.IdAutor = autor.IdAutor;

            //// Eliminar géneros actuales relacionados
            //_context.LibroGeneros.RemoveRange(libro.LibroGeneros);

            //// Agregar los nuevos géneros seleccionados
            //foreach (var idGenero in libroDto.GenerosSeleccionados)
            //{
            //    _context.LibroGeneros.Add(new LibroGenero
            //    {
            //        IdLibro = libro.IdLibro,
            //        IdGeneroLibro = idGenero
            //    });
            //}

            //await _context.SaveChangesAsync();
            //return libro;
            var libro = await _libroRepository.ObtenerPorIdAsync(id);
            if (libro == null)
                throw new ExcepcionLibro();

            var autor = libroDto.AutorId.HasValue
                ? await _autorService.ObtenerPorIdAsync(libroDto.AutorId.Value)
                : await _autorService.ObtenerPorNombreAsync(libroDto.NombreAutor);

            if (autor == null)
                throw new ExcpecionAutor();

            libro.TituloLibro = libroDto.TituloLibro;
            libro.AñoPublicacion = libroDto.AñoPublicacion;
            libro.NumeroDePaginas = libroDto.NumeroDePaginas;
            libro.IdAutor = autor.IdAutor;

            _context.LibroGeneros.RemoveRange(libro.LibroGeneros);

            foreach (var idGenero in libroDto.GenerosSeleccionados)
            {
                _context.LibroGeneros.Add(new LibroGenero
                {
                    IdLibro = libro.IdLibro,
                    IdGeneroLibro = idGenero
                });
            }

            await _libroRepository.ModificarAsync(libro);
            return libro;
        }

        // Eliminar libro
        public async Task<Libro> EliminarLibroAsync(int id)
        {
            //var libro = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == id);
            //if (libro == null)
            //{
            //    throw new ExcepcionLibro();
            //}
            //_context.Libros.Remove(libro);
            //await _context.SaveChangesAsync();
            //return libro;
            var libro = await _libroRepository.ObtenerPorIdAsync(id);
            if (libro == null)
                throw new ExcepcionLibro();

            _context.LibroGeneros.RemoveRange(libro.LibroGeneros);
            await _libroRepository.EliminarAsync(id);
            return libro;
        }
        // Obtener libro por ID
        public async Task<Libro> ObtenerPorIdAsync(int id)
        {
            //return await _context.Libros.Include(l => l.IdAutorNavigation).FirstOrDefaultAsync(l => l.IdLibro == id);
            return await _libroRepository.ObtenerPorIdAsync(id);
        }


        //Se aplica el SP
        public async Task<IEnumerable<LibroConDetalleDTO>> ObtenerLibrosConDetalleSPAsync()
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());

            var result = await connection.QueryAsync<LibroConDetalleDTO>(
                "sp_ObtenerLibrosConDetalle",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
