using System.Collections.Generic;
using Application.POCO;
using MediatR;

namespace Application.UseCases.GetAllGemeente
{
    public class GetAllGemeenteQuery : IRequest<IEnumerable<Gemeente>>
    {
    }
}
