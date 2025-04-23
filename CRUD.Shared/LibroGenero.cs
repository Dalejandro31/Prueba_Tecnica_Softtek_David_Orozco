using System;
using System.Collections.Generic;

namespace CRUD.Shared;

public partial class LibroGenero
{
    public int IdLibroGenero { get; set; }

    public int IdLibro { get; set; }

    public int IdGeneroLibro { get; set; }

    public virtual GeneroLibro IdGeneroLibroNavigation { get; set; } = null!;

    public virtual Libro IdLibroNavigation { get; set; } = null!;
}
