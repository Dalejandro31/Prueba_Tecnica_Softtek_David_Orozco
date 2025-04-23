using System;
using System.Collections.Generic;

namespace CRUD.Shared;

public partial class GeneroLibro
{
    public int IdGeneroLibro { get; set; }

    public string GeneroLibro1 { get; set; } = null!;

    public virtual ICollection<LibroGenero> LibroGeneros { get; set; } = new List<LibroGenero>();
}
