using System;
using System.Collections.Generic;

namespace ApiTrabajador.Model;

public partial class Trabajador
{
    public int Idtrabajador { get; set; }

    public int? Idcargo { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public decimal Salario { get; set; }

    public DateTime Fecharegistro { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public virtual Cargo? CargoNavigation { get; set; }

    public virtual ICollection<Pagotrabajador> Pagotrabajadors { get; set; } = new List<Pagotrabajador>();
}
