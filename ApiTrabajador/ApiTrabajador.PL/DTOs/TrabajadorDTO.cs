namespace ApiTrabajador.PL.DTOs
{
    public class TrabajadorDTO
    {
        public int Idtrabajador { get; set; }

        public string Nombre { get; set; } = null!;

        public int Edad { get; set; }

        public decimal Salario { get; set; }

        public virtual CargoDTO? Cargo { get; set; }
    }
}
