using FigurasApi.Models;
using FigurasApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FigurasApi.Services
{
    public class FiguraService : IFiguraService
    {
        private readonly IFiguraRepository _repository;
        public FiguraService(IFiguraRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Figura>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Figura?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<Figura> AddAsync(Figura figura) => _repository.AddAsync(figura);
        public Task<Figura?> UpdateAsync(Figura figura) => _repository.UpdateAsync(figura);
        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
} 