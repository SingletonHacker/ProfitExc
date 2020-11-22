﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

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
    }
}
