using System;
using System.Collections.Generic;

namespace CRUD.Shared;

public partial class CiudadProcedencium
{
    public int IdCiudadProcedencia { get; set; }

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Autor> Autors { get; set; } = new List<Autor>();
}
