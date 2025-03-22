using CRUD.Backend.DTOs;
using CRUD.Shared;

namespace CRUD.Backend.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<Libro>> ObtenerTodosAsync();
        Task<Libro> ObtenerPorIdAsync(int id);
        Task<Libro> CrearLibroAsync(LibroDTO libroDto);
        Task<Libro> ModificarLibroAsync(int id, LibroDTO libroDto);
        Task<Libro> EliminarLibroAsync(int id);


    }
}
