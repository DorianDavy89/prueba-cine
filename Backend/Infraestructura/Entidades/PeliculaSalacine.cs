using System;
using System.Collections.Generic;

namespace Infraestructura.Entidades;

public partial class PeliculaSalacine
{
    public int IdPeliculaSala { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public DateTime FechaFin { get; set; }

    public int IdPelicula { get; set; }

    public int IdSalaCine { get; set; }

    public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

    public virtual SalaCine IdSalaCineNavigation { get; set; } = null!;
}
