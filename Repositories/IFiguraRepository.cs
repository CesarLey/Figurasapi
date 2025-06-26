using FigurasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FigurasApi.Repositories
{
    public interface IFiguraRepository
    {
        Task<IEnumerable<Figura>> GetAllAsync();
        Task<Figura?> GetByIdAsync(int id);
        Task<Figura> AddAsync(Figura figura);
        Task<Figura?> UpdateAsync(Figura figura);
        Task<bool> DeleteAsync(int id);
    }
} 