using Infraestructura.Persistencias;
using Infraestructura.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public class RepositorioSalaCine: InterfaceSalaCine
    {

        private readonly CineDbContext _context;

        public RepositorioSalaCine(CineDbContext context)
        {
            _context = context;
        }

        public async Task<string> buscarDisponibilidadSalaPorNombreAsync(string nombreSala)
        {
            // validacion
            if (string.IsNullOrWhiteSpace(nombreSala))
            {
                throw new ArgumentException("El nombre de la sala de cine es requerido");
            }

            // buscar
            var sala = await _context.SalaCines
                .FirstOrDefaultAsync(s => s.Nombre.ToLower().Contains(nombreSala.ToLower()));

            if (sala == null)
            {
                throw new KeyNotFoundException($"No se encontro: '{nombreSala}'");
            }

            
            var cantidadPeliculas = await(
                from ps in _context.PeliculaSalacines
                where ps.IdSalaCine == sala.IdSalaCine
                select ps
            ).CountAsync();

            
            string mensaje;

            if (cantidadPeliculas < 3)
            {
                mensaje = "Sala disponible";
            }
            else if (cantidadPeliculas >= 3 && cantidadPeliculas <= 5)
            {
                mensaje = $"Sala con {cantidadPeliculas} películas asignadas";
            }
            else 
            {
                mensaje = "Sala no disponible";
            }

            return mensaje;
        }
    }
}
