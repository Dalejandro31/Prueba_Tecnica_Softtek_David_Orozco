using System.Net.Http.Json;
using CRUD.Frontend.DTOs;
using CRUD.Frontend.Interfaces;
using CRUD.Shared;

namespace CRUD.Frontend.Services
{
    public class AutorService : IAutorService
    {
        private readonly HttpClient _httpClient;

        public AutorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Autor>> ObtenerTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Autor>>("api/Autor");
        }


        public async Task<Autor> ObtenerAutorPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Autor>($"api/Autor/{id}");
        }

        public async Task<string> CrearAutorAsync(Autor autor)
        {
            var response = await _httpClient.PostAsJsonAsync("api/autor", autor);
            if (!response.IsSuccessStatusCode)
            {
                var contenidoError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear Autor: {contenidoError}");
            }

            var contenidoExito = await response.Content.ReadAsStringAsync();
            

            return contenidoExito;
        }

        public async Task<string> ModificarAutorAsync(int id, Autor autor)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Autor/{id}", autor);
            if (!response.IsSuccessStatusCode)
            {
                var contenidoError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al modificar Autor: {contenidoError}");
            }

            var contenidoExito = await response.Content.ReadAsStringAsync();
            

            return contenidoExito;
        }

        public async Task<string> EliminarAutorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Autor/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var contenidoError = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar Autor: {contenidoError}");
            }

            var contenidoExito = await response.Content.ReadAsStringAsync();


            return contenidoExito;
        }
    }
}
