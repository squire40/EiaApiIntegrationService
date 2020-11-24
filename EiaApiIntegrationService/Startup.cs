using EiaApiIntegrationService;
using EiaApiIntegrationService.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

public class Startup
{
    IConfigurationRoot Configuration { get; }

    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IConfigurationRoot>(Configuration);

        ConfigureApiIntegration(services);
        ConfigureRepositories(services);
        var serviceProvider = services.BuildServiceProvider();
        services.AddTransient<IEiaDataHandler>(s => new EiaDataHandler(serviceProvider.GetService<IApiIntegration>()
            , serviceProvider.GetService<ISeriesRepository>()
            , serviceProvider.GetService<IConfigurationRoot>()));
    }

    private void ConfigureRepositories(IServiceCollection services)
    {
        services.AddTransient<ISeriesRepository, SeriesRepository>(c => new SeriesRepository(Configuration.GetConnectionString("EIA")));
    }

    public void ConfigureApiIntegration(IServiceCollection services)
    {
        var client = new RestClient(Configuration.GetSection("AppSettings:ApiBaseUrl").Value);
        var daysCount = int.Parse(Configuration.GetSection("AppSettings:DaysCount").Value);
        var request = new RestRequest($"series/?api_key={Configuration.GetSection("AppSettings:ApiKey").Value}" +
            $"&series_id={Configuration.GetSection("AppSettings:SeriesId").Value}&out=xml");
        services.AddTransient<IApiIntegration>(c => new ApiIntegration(client, request, daysCount));
    }
}