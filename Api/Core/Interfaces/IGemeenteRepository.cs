using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGemeenteRepository
    {
        //TODO PAGING
        Task<IEnumerable<Gemeente>> GetAllGemeentesAsync();

        Task<IEnumerable<Gemeente>> GetAllGemeentesAsync(ISpecification<Gemeente> specification);

        Task AddRangeAsync(IEnumerable<Gemeente> gemeentes);

        Task<Gemeente> GetGemeenteByName(string name);
    }
}
