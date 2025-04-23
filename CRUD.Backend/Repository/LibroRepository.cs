using CRUD.Backend.Data;
using CRUD.Backend.InterfacesRepository;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly DataContext _context;

        public LibroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.LibroGeneros)
                .ThenInclude(g => g.IdGeneroLibroNavigation)
                .ToListAsync();
        }

        public async Task<Libro?> ObtenerPorIdAsync(int id)
        {
            return await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.LibroGeneros)
                .ThenInclude(g => g.IdGeneroLibroNavigation)
                .FirstOrDefaultAsync(l => l.IdLibro == id);
        }

        public async Task<Libro> CrearAsync(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task<Libro> ModificarAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return false;

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
