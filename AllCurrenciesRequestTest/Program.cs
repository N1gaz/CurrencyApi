using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;

namespace AllCurrenciesRequestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://www.cbr-xml-daily.ru/daily_json.js");
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            var testRequest = new GetAllCurrenciesQuery();

            Console.Read();
        }
    }
}
