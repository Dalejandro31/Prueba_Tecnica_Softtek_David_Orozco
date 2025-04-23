using CRUD.Backend.Data;
using CRUD.Backend.InterfacesRepository;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;

        public AutorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> ObtenerTodosAsync()
        {
            return await _context.Autors.Include(a => a.Libros).ToListAsync();
        }

        public async Task<Autor?> ObtenerPorIdAsync(int id)
        {
            return await _context.Autors.Include(a => a.Libros).FirstOrDefaultAsync(a => a.IdAutor == id);
        }

        public async Task<Autor?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Autors.FirstOrDefaultAsync(a => a.Nombre == nombre);
        }

        public async Task<Autor> CrearAsync(Autor autor)
        {

            _context.Autors.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<Autor> ModificarAsync(Autor autor)
        {
            _context.Autors.Update(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var autor = await _context.Autors.FindAsync(id);
            if (autor == null) return false;

            _context.Autors.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
