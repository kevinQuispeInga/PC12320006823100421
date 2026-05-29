using PC12320006823100421.CORE.CORE.Entities;

namespace PC12320006823100421.CORE.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetAll();
        Task<OrdenServicio> GetById(int id);
        Task Create(OrdenServicio ordenServicio);
        Task Update(OrdenServicio ordenServicio);
        Task Delete(int id);
    }
}