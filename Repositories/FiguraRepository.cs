using FigurasApi.Models;
using FigurasApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FigurasApi.Repositories
{
    public class FiguraRepository : IFiguraRepository
    {
        private readonly ApplicationDbContext _context;
        public FiguraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Figura>> GetAllAsync()
        {
            return await _context.Figuras.ToListAsync();
        }

        public async Task<Figura?> GetByIdAsync(int id)
        {
            return await _context.Figuras.FindAsync(id);
        }

        public async Task<Figura> AddAsync(Figura figura)
        {
            figura.CalcularVolumen();
            _context.Figuras.Add(figura);
            await _context.SaveChangesAsync();
            return figura;
        }

        public async Task<Figura?> UpdateAsync(Figura figura)
        {
            var existing = await _context.Figuras.FindAsync(figura.Id);
            if (existing == null) return null;
            existing.TipoFigura = figura.TipoFigura;
            existing.Arista = figura.Arista;
            existing.Radio = figura.Radio;
            existing.Altura = figura.Altura;
            existing.Base = figura.Base;
            existing.Largo = figura.Largo;
            existing.Ancho = figura.Ancho;
            existing.CalcularVolumen();
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var figura = await _context.Figuras.FindAsync(id);
            if (figura == null) return false;
            _context.Figuras.Remove(figura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 