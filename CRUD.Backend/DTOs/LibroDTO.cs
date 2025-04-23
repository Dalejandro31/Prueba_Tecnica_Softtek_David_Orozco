using System.ComponentModel.DataAnnotations;

namespace CRUD.Backend.DTOs
{
    // DTO para Libro
    public class LibroDTO
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string TituloLibro { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        public DateTime AñoPublicacion { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        public int NumeroDePaginas { get; set; }

        public int? AutorId { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        public string NombreAutor { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public List<int> GenerosSeleccionados { get; set; } = new();

    }
}
