using ApiCine.Dtos.PeliculaDto;
using Infraestructura.Entidades;
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
    public class RepositorioPeliculaSala : InterfacePeliculaSalaCine
    {

        private readonly CineDbContext _context;

        public RepositorioPeliculaSala(CineDbContext context)
        {
            _context = context;
        }


        public async Task<List<PeliculasObtenerDto>> buscarPeliculasPorFechaPublicacionAsync(DateTime fechaPublicacion)
        {
            if (fechaPublicacion == default(DateTime))
            {
                throw new ArgumentException("La fecha requerida");
            }

            if (fechaPublicacion < new DateTime(1900, 1, 1) || fechaPublicacion > new DateTime(2100, 12, 31))
            {
                throw new ArgumentException("Rango de fecha no valido");
            }

            var peliculas = await (from ps in _context.PeliculaSalacines
                                   join p in _context.Peliculas on ps.IdPelicula equals p.IdPelicula
                                   where ps.FechaPublicacion.Date == fechaPublicacion.Date
                                   select new PeliculasObtenerDto 
                                   {
                                       IdPelicula = p.IdPelicula,
                                       Nombre = p.Nombre,
                                       Duracion = p.Duracion
                                   })
                           .Distinct()
                           .ToListAsync();

            return peliculas;
        }
    }
}
