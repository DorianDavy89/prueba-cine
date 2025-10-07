using System;
using System.Collections.Generic;

namespace Infraestructura.Entidades;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Nombre { get; set; } = null!;

    public int Duracion { get; set; }

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
