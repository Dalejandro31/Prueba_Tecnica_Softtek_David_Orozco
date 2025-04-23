using System;
using System.Collections.Generic;

namespace CRUD.Shared;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string TituloLibro { get; set; } = null!;

    public DateTime AñoPublicacion { get; set; }

    public int NumeroDePaginas { get; set; }

    public int IdAutor { get; set; }

    public virtual Autor IdAutorNavigation { get; set; } = null!;

    public virtual ICollection<LibroGenero> LibroGeneros { get; set; } = new List<LibroGenero>();
}
