using Infraestructura.Dtos.PeliculaDto;
using Infraestructura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Services
{
    public class ServicioPeliculaSalaCine : IPeliculaSalaCineService
    {
        private readonly IRepositorioPeliculaSalaCine _repositorio;

        public ServicioPeliculaSalaCine(IRepositorioPeliculaSalaCine repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<PeliculasObtenerDto>> buscarPeliculasPorFechaPublicacionAsync(DateTime fechaPublicacion)
        {
            // Validaciones
            if (fechaPublicacion == default)
                throw new ArgumentException("La fecha de publicacion es obligatoria");

            if (fechaPublicacion < new DateTime(1900, 1, 1) || fechaPublicacion > new DateTime(2100, 12, 31))
                throw new ArgumentException("La fecha esta fuera del rango permitido");

            var peliculas = await _repositorio.buscarPeliculasPorFechaPublicacionAsync(fechaPublicacion);

            var peliculasDto = peliculas.Select(p => new PeliculasObtenerDto
            {
                IdPelicula = p.IdPelicula,
                Nombre = p.Nombre,
                Duracion = p.Duracion
            }).ToList();

            return peliculasDto;
        }
    }
}
