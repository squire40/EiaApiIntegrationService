using EiaApiIntegrationService.Models;
using System.Collections.Generic;

namespace EiaApiIntegrationService
{
    public interface IApiIntegration
    {
        eia_apiSeriesRowRow[] GetSeriesData();
    }
}
