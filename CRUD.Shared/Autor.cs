using System;
using System.Collections.Generic;

namespace CRUD.Shared;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string? Correo { get; set; }

    public int IdCiudadProcedencia { get; set; }

    public virtual CiudadProcedencium IdCiudadProcedenciaNavigation { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
