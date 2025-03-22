using CRUD.Shared;

namespace CRUD.Frontend.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<Autor>> ObtenerTodosAsync();
        Task<Autor> ObtenerAutorPorIdAsync(int id);
        Task<string> CrearAutorAsync(Autor autor);
        Task<string> ModificarAutorAsync(int id, Autor autor);

        Task<string> EliminarAutorAsync(int id);

    }
}
