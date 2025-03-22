using CRUD.Shared;
using CRUD.Frontend.DTOs;

namespace CRUD.Frontend.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<Libro>> ObtenerTodosAsync();
        Task<Libro> ObtenerLibroPorIdAsync(int id);
        Task<string> CrearLibroAsync(LibroCrearDto libroDto);
        Task<string> ModificarLibroAsync(int id, LibroCrearDto libroDto);
        Task<string> EliminarLibroAsync(int id);
    }
}
