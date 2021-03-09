using Application.Interfaces;
using MediatR;
using Model.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetCurrencyByCharCodeQuery : IRequest<Currency>
    {
        public string CharCode { get; set; }

        public class GetCurrencyByCharNumQueryHandler: IRequestHandler<GetCurrencyByCharCodeQuery, Currency>
        {
            private readonly Stream responseStream;

            public GetCurrencyByCharNumQueryHandler(ICurrencyValues values)
            {
                responseStream = values.GetCurrencyStream();
            }

            public async Task<Currency> Handle(GetCurrencyByCharCodeQuery request, CancellationToken cancellationToken)
            {
                Response response;

                using (StreamReader reader = new StreamReader(responseStream))
                {
                    response = JsonConvert.DeserializeObject<Response>(await reader.ReadToEndAsync());
                }

                return response.Valute[request.CharCode];
            }
        }
    }
}
