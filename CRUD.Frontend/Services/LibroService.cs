using System.Net.Http.Json;
using CRUD.Frontend.DTOs;
using CRUD.Frontend.Interfaces;
using CRUD.Shared;

namespace CRUD.Frontend.Services
{
    public class LibroService : ILibroService
    {
        private readonly HttpClient _httpClient;

        public LibroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Libro>>("api/libro");
        }

        public async Task<Libro> ObtenerLibroPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Libro>($"api/libro/{id}");
        }

        public async Task<string> CrearLibroAsync(LibroCrearDto libroDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Libro", libroDto);

            if (!response.IsSuccessStatusCode)
            {
                var contenidoError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear libro: {contenidoError}");
            }

            var contenidoExito = await response.Content.ReadAsStringAsync();


            return contenidoExito;
        }

        public async Task<string> ModificarLibroAsync(int id, LibroCrearDto libroDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/libro/{id}", libroDto);
            if (!response.IsSuccessStatusCode)
            {
                var contenidoError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al modificar libro: {contenidoError}");
            }

            var contenidoExito = await response.Content.ReadAsStringAsync();


            return contenidoExito;
        }

        public async Task<string> EliminarLibroAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/libro/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var contenidoError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar libro: {contenidoError}");
            }

            var contenidoExito = await response.Content.ReadAsStringAsync();


            return contenidoExito;
        }


    }
}
