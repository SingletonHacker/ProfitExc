using Application.POCO;
using MediatR;

namespace Application.UseCases.GetGemeenteDetailsByName
{
    public class GetGemeenteDetailsByNameQuery : IRequest<GemeenteDetails>
    {
        public string Name { get; set; }
    }
}
