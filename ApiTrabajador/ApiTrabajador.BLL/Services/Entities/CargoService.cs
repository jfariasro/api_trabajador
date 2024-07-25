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
    public class CargoService : ICargoService
    {
        private readonly IGenericRepository<Cargo> _repository;

        public CargoService(IGenericRepository<Cargo> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Editar(Cargo model, int id)
        {
            return await _repository.Editar(model, id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<IQueryable<Cargo>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<Cargo> Obtener(int id)
        {
            return await _repository.Obtener(id);
        }

        public async Task<bool> Registrar(Cargo model)
        {
            return await _repository.Registrar(model);
        }
    }
}
