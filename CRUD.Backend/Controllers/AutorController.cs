using CRUD.Backend.DTOs;
using CRUD.Backend.Interfaces;
using CRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        // Inyección de dependencias para acceder al servicio de autores
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // Obtener todos los autores registrados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorService.ObtenerTodosAsync();
            return Ok(autores);
        }

        // Obtener un autor específico por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutorId(int id)
        {
            var autor = await _autorService.ObtenerPorIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        // Crear un nuevo autor
        [HttpPost]
        public async Task<ActionResult> CreateAutor([FromBody] AutorDTO autorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _autorService.CrearAutorAsync(autorDto);
            return Ok(new { message = "Autor Creado correctamente" });
        }

        // Modificar un autor 
        [HttpPut("{id}")]
        public async Task<ActionResult> ModificarAutor(int id, [FromBody] AutorDTO autorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _autorService.ModificarAutorAsync(id, autorDto);
                return Ok(new { message = "Autor modificado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Eliminar un autor
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAutor(int id)
        {
            try
            {
                await _autorService.EliminarAutorAsync(id);
                return Ok(new { message = "Autor Eliminado Correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
