using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;


namespace Prome.Viaticos.Server.Api.Web.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected string GetUserAuthorized(string user)
        {
            //var appEmail = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value;
            //return this.HttpContext.User.Identity.Name ?? appEmail;
            //return this.HttpContext.User.Identity.Name ?? "mchuquimia@provinciamicrocreditos.com";
            return user + "@provinciamicrocreditos.com";
        }
    }
}
