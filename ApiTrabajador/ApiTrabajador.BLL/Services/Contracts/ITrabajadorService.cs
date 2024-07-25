using ApiTrabajador.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTrabajador.BLL.Services.Contracts
{
    public interface ITrabajadorService
    {
        Task<bool> Registrar(Trabajador model);

        Task<bool> Editar(Trabajador model, int id);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Trabajador>> Listar();

        Task<Trabajador> Obtener(int id);
    }
}
