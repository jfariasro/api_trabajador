using System;
using System.Collections.Generic;

namespace ApiTrabajador.Model;

public partial class Pagotrabajador
{
    public int Idpagotrabajador { get; set; }

    public int? Idtrabajador { get; set; }

    public DateTime Fechapago { get; set; }

    public decimal Totalpago { get; set; }

    public DateTime Fecharegistro { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public virtual Trabajador? TrabajadorNavigation { get; set; }
}
