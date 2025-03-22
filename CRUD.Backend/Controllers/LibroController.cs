using CRUD.Backend.DTOs;
using CRUD.Backend.Excepciones;
using CRUD.Backend.Interfaces;
using CRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;

        public LibroController(ILibroService libroService, IAutorService autorService)
        {
            _libroService = libroService;
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            var libros = await _libroService.ObtenerTodosAsync();
            return Ok(libros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibroId(int id)
        {
            var libro = await _libroService.ObtenerPorIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpGet("autores")]
        public async Task<IActionResult> GetAutores()
        {
            var autores = await _autorService.ObtenerTodosAsync();
            return Ok(autores);
        }

        


        [HttpPost]
        public async Task<ActionResult> CreateLibro([FromBody] LibroDTO libroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _libroService.CrearLibroAsync(libroDto);
                return StatusCode(201);
            }
            catch (ExcpecionAutor ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (ExcepcionLibro ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ModificarLibro(int id, [FromBody] LibroDTO libroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _libroService.ModificarLibroAsync(id, libroDto);
                return Ok();
            }
            catch (ExcepcionLibro ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLibro(int id)
        {
            try
            {
                await _libroService.EliminarLibroAsync(id);
                return Ok();
            }
            catch (ExcepcionLibro ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
