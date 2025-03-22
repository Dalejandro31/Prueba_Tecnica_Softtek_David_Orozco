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

        // Inyección de dependencias para los servicios de libro y autor
        public LibroController(ILibroService libroService, IAutorService autorService)
        {
            _libroService = libroService;
            _autorService = autorService;
        }


        // Obtener todos los libros registrados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            var libros = await _libroService.ObtenerTodosAsync();
            return Ok(libros);
        }

        // Obtener un libro específico por su ID
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

        // Crear un nuevo libro
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
                return Ok(new { message = "Libro creado correctamente" });
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

        // Modificar un libro
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
                return Ok(new { message = "Libro modificado correctamente" });

            }
            catch (ExcepcionLibro ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Eliminar un libro
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLibro(int id)
        {
            try
            {
                await _libroService.EliminarLibroAsync(id);
                return Ok(new { message = "Libro eliminado correctamente" });
            }
            catch (ExcepcionLibro ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
