using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class GemeenteRepository : Repository<Gemeente, GemeenteContext>, IGemeenteRepository
    {
        private readonly GemeenteContext _context;

        public GemeenteRepository(GemeenteContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Gemeente>> GetAllGemeentesAsync()
        {
            return Task.FromResult((IEnumerable<Gemeente>)_context.Gemeentes);
        }

        public async Task<IEnumerable<Gemeente>> GetAllGemeentesAsync(ISpecification<Gemeente> specification)
        {
            if (specification.OrderBy == null)
            {
                throw new ArgumentException("No specification was provided");
            }

            var query = _context.Set<Gemeente>().AsQueryable();

            var orderedQuery = query.OrderBy(specification.OrderBy);

            return await orderedQuery.ToListAsync();
        }

        public async Task<Gemeente> GetGemeenteByName(string name)
        {
            var query = _context.Set<Gemeente>().AsQueryable();

            return await query.SingleOrDefaultAsync(q => q.Name == name);
        }
    }
}
