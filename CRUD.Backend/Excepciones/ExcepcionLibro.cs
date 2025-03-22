namespace CRUD.Backend.Excepciones
{
    public class ExcepcionLibro : Exception
    {
        public ExcepcionLibro() : base("No es posible registrar el libro, se alcanzó el máximo permitido.")
        {
        }
    }
}
