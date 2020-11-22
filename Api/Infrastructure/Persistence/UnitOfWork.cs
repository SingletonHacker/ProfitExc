using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GemeenteContext _gemeenteContext;

        public UnitOfWork(IGemeenteRepository gemeenteRepository, GemeenteContext gemeenteContext)
        {
            GemeenteRepository = gemeenteRepository;
            _gemeenteContext = gemeenteContext;
        }

        public IGemeenteRepository GemeenteRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _gemeenteContext.SaveChangesAsync();
        }
    }
}
