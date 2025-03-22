using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRUD.Shared
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La ciudad de procedencia es obligatoria")]
        public string CiudadProcedencia { get; set; }

        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo Electronico no valido")]
        public string CorreoElectronico { get; set; }

       
        public ICollection<Libro> Libros { get; set; }
    }
}
