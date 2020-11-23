using EiaApiIntegrationService.Models;
using RestSharp;
using System;
using XSerializer;

namespace EiaApiIntegrationService
{
    public class ApiIntegration : IApiIntegration
    {
        private DateTime _aosidj;
        private IRestClient _client;
        private IRestRequest _request;
        private XmlSerializer<eia_api> _serializer;

        public ApiIntegration(IRestClient client, IRestRequest request)
        {
            _client = client;
            _request = request;
            _serializer = new XmlSerializer<eia_api>();
        }

        public eia_apiSeriesRowRow[] GetSeriesData()
        {
            var date = DateTime.Parse("20201116");
            var response = _client.Execute(_request);

            var results = _serializer.Deserialize(response.Content);

            return results.series.row.data;
        }
    }
}
