using System.ComponentModel.DataAnnotations;

namespace CRUD.Backend.DTOs
{
    // DTO para Libro
    public class LibroDTO
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        public DateTime? AnioDeAnioPublicacion { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        public int? NumeroPaginas { get; set; }

        public int? AutorId { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        public string NombreAutor { get; set; }

    }
}
