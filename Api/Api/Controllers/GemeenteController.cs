using System.Collections.Generic;
using System.Threading.Tasks;
using Application.POCO;
using Application.UseCases.GetAllGemeente;
using Application.UseCases.GetGemeenteDetailsByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class GemeenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GemeenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Gemeente>> Get(string orderBy = nameof(Gemeente.Name))
        {
            return await _mediator.Send(new GetAllGemeenteQuery { OrderBy = orderBy });
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<GemeenteDetails> GetByName(string name)
        {
            return await _mediator.Send(new GetGemeenteDetailsByNameQuery { Name = name });
        }
    }
}
