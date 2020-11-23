using RestSharp;
using System;
using Xunit;
using EiaApiIntegrationService;

namespace ApiIntegrationService.Tests.Integration
{
    public class ApiIntegrationTests
    {
        private RestClient _client;
        private RestRequest _request;
        private IApiIntegration _api;

        public ApiIntegrationTests()
        {
            _client = new RestClient("http://api.eia.gov/");
            _request = new RestRequest($"series/?api_key=ec92aacd6947350dcb894062a4ad2d08" +
            $"&series_id=PET.EMD_EPD2D_PTE_NUS_DPG.W&out=xml");
            _api = new ApiIntegration(_client, _request, 5);
        }

        [Fact]
        public void Test1()
        {
            //Arrange

            //Act
            var result = _api.GetSeriesData();

            //Assert
            Assert.NotNull(result);
        }
    }
}
