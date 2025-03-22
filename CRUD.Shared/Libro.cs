using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRUD.Shared
{
    public class Libro
    {
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        public DateTime AnioDeAnioPublicacion { get; set; }

        [Required(ErrorMessage = "El genero es obligatorio")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El numero de paginas es obligatorio")]
        public int NumeroPaginas { get; set; }

        //llave foranea
        [Required(ErrorMessage = "El autor es obligatorio")]
        public int AutorId { get; set; }


       
        public virtual Autor Autor { get; set; }
    }
}
