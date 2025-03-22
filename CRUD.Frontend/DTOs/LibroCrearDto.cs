namespace CRUD.Frontend.DTOs
{
    public class LibroCrearDto
    {
        public string Titulo { get; set; }
        public DateTime? AnioDeAnioPublicacion { get; set; }
        public string Genero { get; set; }
        public int? NumeroPaginas { get; set; }
        public string NombreAutor { get; set; }
    }
}
