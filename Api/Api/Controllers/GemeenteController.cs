using System.Collections.Generic;
using System.Threading.Tasks;
using Application.POCO;
using Application.UseCases.GetAllGemeente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class GemeenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GemeenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Gemeente>> Get()
        {
            return await _mediator.Send(new GetAllGemeenteQuery());
        }
    }
}
