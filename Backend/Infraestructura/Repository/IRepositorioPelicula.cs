using Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public interface IRepositorioPelicula
    {
        Task registrarPeliculaAsync(Pelicula pelicula);
        Task<List<Pelicula>> getPeliculasAsync();
        Task<bool> actualizarPeliculaAsync(int id, Pelicula pelicula);
        Task<bool> eliminarPeliculaAsync(int id);
        Task<List<Pelicula>> buscarPeliculaPorNombreAsync(string nombre);
    }
}
