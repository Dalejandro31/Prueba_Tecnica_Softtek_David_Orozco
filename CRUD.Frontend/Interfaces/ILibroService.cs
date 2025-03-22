using CRUD.Shared;
using CRUD.Frontend.DTOs;

namespace CRUD.Frontend.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<Libro>> ObtenerTodosAsync();
        Task<Libro> ObtenerLibroPorIdAsync(int id);
        Task CrearLibroAsync(LibroCrearDto libroDto);
        Task ModificarLibroAsync(int id, LibroCrearDto libroDto);
        Task EliminarLibroAsync(int id);
    }
}
