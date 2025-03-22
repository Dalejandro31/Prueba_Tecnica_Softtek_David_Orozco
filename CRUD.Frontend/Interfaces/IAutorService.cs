using CRUD.Shared;

namespace CRUD.Frontend.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<Autor>> ObtenerTodosAsync();
        Task<Autor> ObtenerAutorPorIdAsync(int id);
        Task CrearAutorAsync(Autor autor);
        Task ModificarAutorAsync(int id, Autor autor);
        Task EliminarAutorAsync(int id);

    }
}
