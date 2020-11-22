using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IGemeenteRepository GemeenteRepository { get; }

        Task SaveChangesAsync();
    }
}
