using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Services
{
    public interface InterfaceSalaCine
    {
        Task<string> buscarDisponibilidadSalaPorNombreAsync(string nombreSala);
    }
}
