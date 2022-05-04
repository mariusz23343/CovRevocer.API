using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CovRecover.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private IMediator mediator;

        protected IMediator _mediator => mediator ??= HttpContext
            .RequestServices.GetService<IMediator>();
    }
}
