using CRUD.Backend.DTOs;
using CRUD.Shared;

namespace CRUD.Backend.Interfaces
{
    // Interfaz que define las operaciones disponibles para los autores
    public interface IAutorService
    {
        Task<IEnumerable<Autor>> ObtenerTodosAsync();
        Task<Autor> ObtenerPorIdAsync(int id);
        Task<Autor> ObtenerPorNombreAsync(string nombre);
        Task<Autor> CrearAutorAsync(AutorDTO autorDto);
        Task<Autor> ModificarAutorAsync(int id, AutorDTO autorDto);
        Task<Autor> EliminarAutorAsync(int id);
    }
}
