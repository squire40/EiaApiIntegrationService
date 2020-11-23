using EiaApiIntegrationService.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using XSerializer;

namespace EiaApiIntegrationService
{
    public class ApiIntegration : IApiIntegration
    {
        private IRestClient _client;
        private IRestRequest _request;
        private XmlSerializer<eia_api> _serializer;
        private int _daysCount;

        public ApiIntegration(IRestClient client, IRestRequest request, int daysCount)
        {
            _client = client;
            _request = request;
            _serializer = new XmlSerializer<eia_api>();
            _daysCount = daysCount;
        }

        public List<eia_apiSeriesRowRow> GetSeriesData()
        {
            var response = _client.Execute(_request);

            var results = _serializer.Deserialize(response.Content);

            return results.series.row.data.Where(x => x.ParsedDate > DateTime.Now.AddDays(_daysCount * -1)).ToList();
        }
    }
}
