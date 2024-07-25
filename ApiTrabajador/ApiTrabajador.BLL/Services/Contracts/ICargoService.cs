using ApiTrabajador.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTrabajador.BLL.Services.Contracts
{
    public interface ICargoService
    {
        Task<bool> Registrar(Cargo model);

        Task<bool> Editar(Cargo model, int id);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Cargo>> Listar();

        Task<Cargo> Obtener(int id);
    }
}
