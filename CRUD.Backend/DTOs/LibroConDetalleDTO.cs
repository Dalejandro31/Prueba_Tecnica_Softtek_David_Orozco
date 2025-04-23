namespace CRUD.Backend.DTOs
{
    public class LibroConDetalleDTO
    {
        public int IdLibro { get; set; }
        public string TituloLibro { get; set; }
        public DateTime AñoPublicacion { get; set; }
        public int NumeroDePaginas { get; set; }

        public int IdAutor { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidoAutor { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public string? Generos { get; set; } 
    }
}
