using System;
using System.IO;
using System.Net;
using Model.Entities;
using Newtonsoft.Json;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://www.cbr-xml-daily.ru/daily_json.js");
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Response testResponse = JsonConvert.DeserializeObject<Response>(reader.ReadToEnd());

            var values = testResponse.Valute;

            Console.ReadKey();
        }
    }
}
