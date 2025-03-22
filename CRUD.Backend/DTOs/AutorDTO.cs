using System.ComponentModel.DataAnnotations;

namespace CRUD.Backend.DTOs
{
    // DTO para autor
    public class AutorDTO
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La ciudad de procedencia es obligatoria")]
        public string CiudadProcedencia { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string CorreoElectronico { get; set; }
    }
}
