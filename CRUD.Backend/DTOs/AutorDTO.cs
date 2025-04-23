using System.ComponentModel.DataAnnotations;

namespace CRUD.Backend.DTOs
{
    // DTO para autor
    public class AutorDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateOnly FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La ciudad de procedencia es obligatoria")]
        public int IdCiudadProcedencia { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string CorreoElectronico { get; set; }
    }
}
