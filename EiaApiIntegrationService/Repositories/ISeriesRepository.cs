using EiaApiIntegrationService.Entities;
using System;
using System.Collections.Generic;

namespace EiaApiIntegrationService.Repositories
{
    public interface ISeriesRepository
    {
        List<SeriesData> GetList(DateTime startDate, DateTime endDate);
        void Save(DateTime createdDate, decimal value, bool isDelete);
    }
}