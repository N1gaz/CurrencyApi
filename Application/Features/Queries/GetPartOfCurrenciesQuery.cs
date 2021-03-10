using Application.Interfaces;
using MediatR;
using Model.Behaviour;
using Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetPartOfCurrenciesQuery : IRequest<IEnumerable<Currency>>
    {
        public int Count { get; set; }
        public int Page { get; set; }

        public class GetPartOfCurrenciesQueryHandler : IRequestHandler<GetPartOfCurrenciesQuery, IEnumerable<Currency>>
        {
            private readonly Stream responseStream;

            public GetPartOfCurrenciesQueryHandler(ICurrencyValues values)
            {
                responseStream = values.GetCurrencyStream();
            }

            public async Task<IEnumerable<Currency>> Handle(GetPartOfCurrenciesQuery request, CancellationToken cancellationToken)
            {
                Response response;

                using (StreamReader reader = new StreamReader(responseStream))
                {
                    response = JsonConvert.DeserializeObject<Response>(await reader.ReadToEndAsync());
                }
                //Первый индекс нулевой, следовательно начинаем с нулевой страницы
                return response.Valute.Select(value => value.Value).ToList()
                    .GetPageEntities(request.Page - 1, request.Count);
            }
        }
    }
}
