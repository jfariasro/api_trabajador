using ApiTrabajador.DAL.Context;
using ApiTrabajador.DAL.Repositories.Contracts;
using ApiTrabajador.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTrabajador.DAL.Repositories.Entities
{
    public class CargoRepository : IGenericRepository<Cargo>
    {
        private readonly DbapitrabajadorContext _context;

        public CargoRepository(DbapitrabajadorContext context)
        {
            _context = context;
        }

        public async Task<bool> Editar(Cargo model, int id)
        {
            try
            {

                var cargo = await _context.Cargos.FindAsync(id);

                if (cargo == null)
                    return false;

                model.Fecharegistro = cargo.Fecharegistro;
                _context.Entry(cargo).CurrentValues.SetValues(model);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var cargo = await _context.Cargos.FindAsync(id);

                if (cargo == null)
                    return false;

                _context.Cargos.Remove(cargo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<IQueryable<Cargo>> Listar()
        {
            return _context.Cargos;
        }

        public async Task<Cargo> Obtener(int id)
        {
            return await _context.Cargos.SingleOrDefaultAsync(c => c.Idcargo == id);
        }

        public async Task<bool> Registrar(Cargo model)
        {
            try
            {
                await _context.Cargos.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
