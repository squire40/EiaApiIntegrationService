using RestSharp;

namespace EiaApiIntegrationService
{
    public class ApiIntegration : IApiIntegration
    {
        private IRestClient _client;
        private IRestRequest _request;

        public ApiIntegration(IRestClient client, IRestRequest request)
        {
            _client = client;
            _request = request;
        }

        public string GetSeriesData()
        {
            var response = _client.Execute(_request);

            return response.Content;
        }
    }
}
