using Microsoft.EntityFrameworkCore;
using PC12320006823100421.CORE.CORE.Entities;
using PC12320006823100421.CORE.Core.Interfaces;
using PC12320006823100421.CORE.Infrastructure.Data;

namespace PC12320006823100421.CORE.Infrastructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerMecanicoDbContext _context;

        public OrdenServicioRepository(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenServicio>> GetAll()
        {
            return await _context.OrdenServicio.ToListAsync();
        }

        public async Task<OrdenServicio> GetById(int id)
        {
            return await _context.OrdenServicio.FindAsync(id);
        }

        public async Task Create(OrdenServicio ordenServicio)
        {
            _context.OrdenServicio.Add(ordenServicio);
            await _context.SaveChangesAsync();
        }

        public async Task Update(OrdenServicio ordenServicio)
        {
            _context.OrdenServicio.Update(ordenServicio);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ordenServicio = await _context.OrdenServicio.FindAsync(id);

            if (ordenServicio != null)
            {
                _context.OrdenServicio.Remove(ordenServicio);
                await _context.SaveChangesAsync();
            }
        }
    }
}