using PC12320006823100421.CORE.CORE.Entities;
using PC12320006823100421.CORE.Core.Interfaces;

namespace PC12320006823100421.CORE.Core.Services
{
    public class OrdenServicioService : IOrdenServicioService
    {
        private readonly IOrdenServicioRepository _repository;

        public OrdenServicioService(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrdenServicio>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<OrdenServicio> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(OrdenServicio ordenServicio)
        {
            await _repository.Create(ordenServicio);
        }

        public async Task Update(OrdenServicio ordenServicio)
        {
            await _repository.Update(ordenServicio);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}