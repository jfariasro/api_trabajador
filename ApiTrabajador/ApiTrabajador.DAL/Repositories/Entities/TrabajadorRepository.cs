using ApiTrabajador.DAL.Context;
using ApiTrabajador.DAL.Repositories.Contracts;
using ApiTrabajador.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTrabajador.DAL.Repositories.Entities
{
    public class TrabajadorRepository : IGenericRepository<Trabajador>
    {
        private readonly DbapitrabajadorContext _context;

        public TrabajadorRepository(DbapitrabajadorContext context)
        {
            _context = context;
        }

        public async Task<bool> Editar(Trabajador model, int id)
        {
            try
            {

                var trabajador = await _context.Trabajadors.FindAsync(id);

                if (trabajador == null)
                    return false;

                model.Fecharegistro = trabajador.Fecharegistro;
                _context.Entry(trabajador).CurrentValues.SetValues(model);

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
                var trabajador = await _context.Trabajadors.FindAsync(id);

                if (trabajador == null)
                    return false;

                _context.Trabajadors.Remove(trabajador);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<IQueryable<Trabajador>> Listar()
        {
            return _context.Trabajadors.Include(c => c.CargoNavigation);
        }

        public async Task<Trabajador> Obtener(int id)
        {
            return await _context.Trabajadors.Include(c => c.CargoNavigation).SingleOrDefaultAsync(e => e.Idtrabajador == id);
        }

        public async Task<bool> Registrar(Trabajador model)
        {
            try
            {
                await _context.Trabajadors.AddAsync(model);
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
