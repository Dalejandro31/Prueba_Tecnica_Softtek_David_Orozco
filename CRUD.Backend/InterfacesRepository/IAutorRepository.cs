using CRUD.Shared;

namespace CRUD.Backend.InterfacesRepository
{
    public interface IAutorRepository 
    {
        Task<IEnumerable<Autor>> ObtenerTodosAsync();
        Task<Autor?> ObtenerPorIdAsync(int id);
        Task<Autor?> ObtenerPorNombreAsync(string nombre);
        Task<Autor> CrearAsync(Autor autor);
        Task<Autor> ModificarAsync(Autor autor);
        Task<bool> EliminarAsync(int id);
    }
}
