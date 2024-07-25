using ApiTrabajador.BLL.Services.Contracts;
using ApiTrabajador.DAL.Repositories.Contracts;
using ApiTrabajador.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTrabajador.BLL.Services.Entities
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly IGenericRepository<Trabajador> _repository;

        public TrabajadorService(IGenericRepository<Trabajador> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Editar(Trabajador model, int id)
        {
            return await _repository.Editar(model, id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<IQueryable<Trabajador>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<Trabajador> Obtener(int id)
        {
            return await _repository.Obtener(id);
        }

        public async Task<bool> Registrar(Trabajador model)
        {
            return await _repository.Registrar(model);
        }
    }
}
