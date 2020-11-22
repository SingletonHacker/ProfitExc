using System.Threading;
using System.Threading.Tasks;
using Application.POCO;
using Core.Interfaces;
using MediatR;

namespace Application.UseCases.GetGemeenteDetailsByName
{
    public class GetGemeenteDetailsByNameQueryHandler : IRequestHandler<GetGemeenteDetailsByNameQuery, GemeenteDetails>
    {
        private readonly IGemeenteRepository _gemeenteRepository;

        public GetGemeenteDetailsByNameQueryHandler(IGemeenteRepository gemeenteRepository)
        {
            _gemeenteRepository = gemeenteRepository;
        }

        public async Task<GemeenteDetails> Handle(GetGemeenteDetailsByNameQuery request, CancellationToken cancellationToken)
        {
            var gemeente = await _gemeenteRepository.GetGemeenteByName(request.Name);

            if (gemeente == null)
            {
                return null;
            }

            return new GemeenteDetails
            {
                Name = gemeente.Name,
                Inwoners = gemeente.AantalInwoners,
                Provincie = new Provincie
                {
                    name = gemeente.Provincie.Name,
                    hoofdstad = gemeente.Provincie.Hoofdstad,
                    oppervlakte_km2 = gemeente.Provincie.OppervlakteKm2
                }
            };
        }
    }
}
