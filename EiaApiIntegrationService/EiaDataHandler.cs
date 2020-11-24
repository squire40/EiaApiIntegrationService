using EiaApiIntegrationService.Entities;
using EiaApiIntegrationService.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EiaApiIntegrationService
{
    public class EiaDataHandler : IEiaDataHandler
    {
        private readonly IApiIntegration _apiIntegration;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IConfigurationRoot _configuration;

        public EiaDataHandler(IApiIntegration apiIntegration, ISeriesRepository seriesRepository, IConfigurationRoot configuration)
        {
            _apiIntegration = apiIntegration;
            _seriesRepository = seriesRepository;
            _configuration = configuration;
        }

        public void StoreWeeklyData()
        {
            var weeklyDataList = _apiIntegration.GetSeriesData();

            var daysCount = int.Parse(_configuration.GetSection("AppSettings:DaysCount").Value);

            var existingData = _seriesRepository.GetList(DateTime.Now.AddDays(daysCount * -1), DateTime.Now);

            var newList = weeklyDataList.Where(w => existingData.All(e => e.CreatedDate != w.ParsedDate)).ToList();

            foreach (var seriesData in newList)
            {
                var series = new SeriesData()
                {
                    CreatedDate = seriesData.ParsedDate,
                    Value = seriesData.value
                };

                _seriesRepository.Save(series.CreatedDate, series.Value, false);
            }
        }
    }
}
