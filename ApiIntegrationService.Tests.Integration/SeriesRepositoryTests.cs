using EiaApiIntegrationService.Entities;
using EiaApiIntegrationService.Repositories;
using Exceptionless;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApiIntegrationService.Tests.Integration
{
    public class SeriesRepositoryTests : IDisposable
    {
        private string _connectionString;
        private ISeriesRepository _seriesRepository;
        private List<SeriesData> _seriesDataList;

        public SeriesRepositoryTests()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EIA;Integrated Security=True;";
            _seriesRepository = new SeriesRepository(_connectionString);
            _seriesDataList = new List<SeriesData>();
        }

        [Fact]
        public void GetList_Happy_Path()
        {
            //Arrange
            for (int i = 0; i < 5; i++)
            {
                _seriesDataList.Add(new SeriesData()
                {
                    CreatedDate = DateTime.Now.AddDays(i),
                    Value = RandomData.GetDecimal(1, 5)
                });

                _seriesRepository.Save(_seriesDataList[i].CreatedDate, _seriesDataList[i].Value, false);
            }
            //Act
            var seriesData = _seriesRepository.GetList(_seriesDataList[0].CreatedDate, _seriesDataList[4].CreatedDate);

            //Assert
            Assert.Equal(5, seriesData.Count);
        }

        public void Dispose()
        {
            foreach (var seriesData in _seriesDataList)
            {
                _seriesRepository.Save(seriesData.CreatedDate, seriesData.Value, true);
            }
        }
    }
}
