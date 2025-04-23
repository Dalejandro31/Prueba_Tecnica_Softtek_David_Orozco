using System;
using CRUD.Backend.Data;
using CRUD.Backend.DTOs;
using CRUD.Backend.Interfaces;
using CRUD.Backend.InterfacesRepository;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Services
{
    public class AutorService : IAutorService
    {
        //private readonly DataContext _context;
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            //_context = context;
            _autorRepository = autorRepository;
        }

        // Obtener todos los autores con sus libros
        public async Task<IEnumerable<Autor>> ObtenerTodosAsync()
        {
            //return await _context.Autors.Include(a => a.Libros).ToListAsync();
            return await _autorRepository.ObtenerTodosAsync();
        }

        // Crear un nuevo autor a partir del DTO recibido
        public async Task<Autor> CrearAutorAsync(AutorDTO autorDto)
        {
            //var ciudad = await _context.CiudadProcedencia.FirstOrDefaultAsync(c => c.IdCiudadProcedencia == autorDto.IdCiudadProcedencia);
            //if (ciudad == null)
            //{
            //    throw new Exception("Ciudad no encontrada");
            //}
            //var autor = new Autor { 
            //    Nombre = autorDto.Nombre,
            //    Apellido = autorDto.Apellido,
            //    FechaNacimiento = autorDto.FechaNacimiento,
            //    Correo = autorDto.CorreoElectronico,
            //    IdCiudadProcedencia = ciudad.IdCiudadProcedencia

            //};
            //_context.Autors.Add(autor);
            //await _context.SaveChangesAsync();
            //return autor;
            var autor = new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaNacimiento = autorDto.FechaNacimiento,
                Correo = autorDto.CorreoElectronico,
                IdCiudadProcedencia = autorDto.IdCiudadProcedencia
            };

            return await _autorRepository.CrearAsync(autor);
        }

        // Buscar un autor por ID
        public async Task<Autor> ObtenerPorIdAsync(int id)
        {
            //return await _context.Autors.FirstOrDefaultAsync(a => a.IdAutor == id);
            return await _autorRepository.ObtenerPorIdAsync(id);
        }

        // Buscar un autor por su nombre
        public async Task<Autor> ObtenerPorNombreAsync(string nombre)
        {
            //return await _context.Autors.FirstOrDefaultAsync(a => a.Nombre == nombre);
            return await _autorRepository.ObtenerPorNombreAsync(nombre);
        }

        // Modificar datos de un autor
        public async Task<Autor> ModificarAutorAsync(int id, AutorDTO autorDto)
        {
            //var autor = await _context.Autors.FirstOrDefaultAsync(a => a.IdAutor == id);
            //if (autor == null)
            //{
            //    throw new Exception("Autor no encontrado");
            //}
            //autor.Nombre = autorDto.Nombre;
            //autor.Apellido = autorDto.Apellido;
            //autor.FechaNacimiento = autorDto.FechaNacimiento;
            //autor.Correo = autorDto.CorreoElectronico;
            //autor.IdCiudadProcedencia = autorDto.IdCiudadProcedencia;

            //await _context.SaveChangesAsync();
            //return autor;
            var autor = await _autorRepository.ObtenerPorIdAsync(id);
            if (autor == null)
                throw new Exception("Autor no encontrado");

            autor.Nombre = autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;
            autor.FechaNacimiento = autorDto.FechaNacimiento;
            autor.Correo = autorDto.CorreoElectronico;
            autor.IdCiudadProcedencia = autorDto.IdCiudadProcedencia;

            return await _autorRepository.ModificarAsync(autor);
        }

        // Eliminar un autor
        public async Task<Autor> EliminarAutorAsync(int id)
        {
            //var autor = await _context.Autors.FirstOrDefaultAsync(a => a.IdAutor == id);
            //if (autor == null)
            //{
            //    throw new Exception("Autor no encontrado");
            //}
            //_context.Autors.Remove(autor);
            //await _context.SaveChangesAsync();
            //return autor;

            var autor = await _autorRepository.ObtenerPorIdAsync(id);
            if (autor == null)
                throw new Exception("Autor no encontrado");

            await _autorRepository.EliminarAsync(id);
            return autor;
        }


    }
}
