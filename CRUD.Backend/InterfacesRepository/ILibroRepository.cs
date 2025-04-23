using CRUD.Shared;

namespace CRUD.Backend.InterfacesRepository
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> ObtenerTodosAsync();
        Task<Libro?> ObtenerPorIdAsync(int id);
        Task<Libro> CrearAsync(Libro libro);
        Task<Libro> ModificarAsync(Libro libro);
        Task<bool> EliminarAsync(int id);
    }
}
