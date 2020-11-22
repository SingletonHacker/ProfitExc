using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.POCO;
using Core.Interfaces;
using MediatR;

namespace Application.UseCases.GetAllGemeente
{
    public class GetAllGemeenteQueryHandler : IRequestHandler<GetAllGemeenteQuery, IEnumerable<Gemeente>>
    {
        private readonly IGemeenteRepository _gemeenteRepository;

        public GetAllGemeenteQueryHandler(IGemeenteRepository gemeenteRepository)
        {
            _gemeenteRepository = gemeenteRepository;
        }

        public async Task<IEnumerable<Gemeente>> Handle(GetAllGemeenteQuery request, CancellationToken cancellationToken)
        {
            var orderBySpecification = new Specification();

            switch (request.OrderBy.ToLower())
            {
                case "inwoners":
                    orderBySpecification.OrderBy = (g) => g.AantalInwoners;
                    break;

                case "name":
                    orderBySpecification.OrderBy = (g) => g.Name;
                    break;

                default:
                    orderBySpecification.OrderBy = (g) => g.Name;
                    break;
            }

            var gemeentes = await _gemeenteRepository.GetAllGemeentesAsync(orderBySpecification);

            return gemeentes.Select(g => new Gemeente { Name = g.Name, Inwoners = g.AantalInwoners, Provincie = g?.Provincie?.Name }).ToList();
        }
    }
}
