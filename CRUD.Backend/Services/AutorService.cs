using System;
using CRUD.Backend.Data;
using CRUD.Backend.DTOs;
using CRUD.Backend.Interfaces;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Services
{
    public class AutorService : IAutorService
    {
        private readonly DataContext _context;

        public AutorService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los autores con sus libros
        public async Task<IEnumerable<Autor>> ObtenerTodosAsync()
        {
            return await _context.Autores.Include(a => a.Libros).ToListAsync();
        }

        // Crear un nuevo autor a partir del DTO recibido
        public async Task<Autor> CrearAutorAsync(AutorDTO autorDto)
        {
            var autor = new Autor { 
                NombreCompleto = autorDto.NombreCompleto,
                FechaNacimiento = autorDto.FechaNacimiento ?? DateTime.MinValue,
                CiudadProcedencia = autorDto.CiudadProcedencia,
                CorreoElectronico = autorDto.CorreoElectronico
            };
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        // Buscar un autor por ID
        public async Task<Autor> ObtenerPorIdAsync(int id)
        {
            return await _context.Autores.FirstOrDefaultAsync(a => a.AutorId == id);
        }

        // Buscar un autor por su nombre
        public async Task<Autor> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Autores.FirstOrDefaultAsync(a => a.NombreCompleto == nombre);
        }

        // Modificar datos de un autor
        public async Task<Autor> ModificarAutorAsync(int id, AutorDTO autorDto)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.AutorId == id);
            if (autor == null)
            {
                throw new Exception("Autor no encontrado");
            }
            autor.NombreCompleto = autorDto.NombreCompleto;
            autor.FechaNacimiento = autorDto.FechaNacimiento ?? DateTime.MinValue;
            autor.CiudadProcedencia = autorDto.CiudadProcedencia;
            autor.CorreoElectronico = autorDto.CorreoElectronico;

            await _context.SaveChangesAsync();
            return autor;
        }

        // Eliminar un autor
        public async Task<Autor> EliminarAutorAsync(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.AutorId == id);
            if (autor == null)
            {
                throw new Exception("Autor no encontrado");
            }
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return autor;
        }


    }
}
