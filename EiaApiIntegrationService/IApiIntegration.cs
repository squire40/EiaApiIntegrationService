using EiaApiIntegrationService.Models;
using System.Collections.Generic;

namespace EiaApiIntegrationService
{
    public interface IApiIntegration
    {
        List<eia_apiSeriesRowRow> GetSeriesData();
    }
}
