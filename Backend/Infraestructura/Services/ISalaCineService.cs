using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Services
{
    public interface ISalaCineService
    {
        Task<string> buscarDisponibilidadSalaPorNombreAsync(string nombreSala);
    }
}
