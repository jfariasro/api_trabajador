using System;
using System.Collections.Generic;

namespace ApiTrabajador.Model;

public partial class Cargo
{
    public int Idcargo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime Fecharegistro { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
