using System;
using System.Collections.Generic;

namespace Infraestructura.Entidades;

public partial class SalaCine
{
    public int IdSalaCine { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
