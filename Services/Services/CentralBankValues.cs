using Application.Interfaces;
using System.IO;
using System.Net;

namespace Services.Services
{
    public class CentralBankValues : ICurrencyValues
    {
        public Stream GetCurrencyStream()
        {
            WebRequest request = WebRequest.Create("https://www.cbr-xml-daily.ru/daily_json.js");

            try
            {
                WebResponse response = request.GetResponse();
                return response.GetResponseStream();
            }
            catch
            {
                return null;
            }
        }
    }
}
