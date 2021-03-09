using System.Threading.Tasks;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AppWebApi.Controllers
{
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("currencies")]
        public async Task<JsonResult> GetAllCurrencies()
        {
            return new JsonResult(Ok(await Mediator.Send(new GetAllCurrenciesQuery())));
        }

        [HttpGet("currencies/{count:int}/{page:int}")]
        public async Task<JsonResult> GetPartOfCurrencies(int count, int page)
        {
            return new JsonResult(Ok(await Mediator.Send(new GetPartOfCurrenciesQuery { Count = count, Page = page })));
        }

        [HttpGet("currency/{charCode}")]
        public async Task<JsonResult> GetCurrency(string charCode)
        {
            return new JsonResult(Ok(await Mediator.Send(new GetCurrencyByCharCodeQuery { CharCode = charCode })));
        }
    }
}
