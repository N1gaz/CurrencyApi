using Application.Interfaces;
using MediatR;
using Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetAllCurrenciesQuery : IRequest<IEnumerable<Currency>>
    {
        public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, IEnumerable<Currency>>
        {
            private readonly Stream _responseStream;

            public GetAllCurrenciesQueryHandler(ICurrencyValues values)
            {
                _responseStream = values.GetCurrencyStream();
            }

            public async Task<IEnumerable<Currency>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
            {
                Response response;

                using (StreamReader reader = new StreamReader(_responseStream))
                {
                    response = JsonConvert.DeserializeObject<Response>(await reader.ReadToEndAsync());
                }

                return response.Valute.Select(value => value.Value).ToList();
            }
        }
    }
}
