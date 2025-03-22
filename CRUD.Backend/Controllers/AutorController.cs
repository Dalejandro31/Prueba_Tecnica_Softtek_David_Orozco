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

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorService.ObtenerTodosAsync();
            return Ok(autores);
        }

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

        [HttpPost]
        public async Task<ActionResult> CreateAutor([FromBody] AutorDTO autorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _autorService.CrearAutorAsync(autorDto);
            return StatusCode(201); 
        }

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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAutor(int id)
        {
            try
            {
                await _autorService.EliminarAutorAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
