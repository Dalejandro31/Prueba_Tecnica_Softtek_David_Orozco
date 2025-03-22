using System.ComponentModel.DataAnnotations;

namespace CRUD.Frontend.DTOs
{
    public class LibroCrearDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El año es obligatorio")]
        public DateTime? AnioDeAnioPublicacion { get; set; }
        [Required(ErrorMessage = "El genero es obligatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El numero de paginas es obligatorio")]
        public int? NumeroPaginas { get; set; }
        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        public string NombreAutor { get; set; }
    }
}
