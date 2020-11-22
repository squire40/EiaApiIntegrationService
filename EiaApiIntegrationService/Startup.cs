using EiaApiIntegrationService;
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
        services.AddTransient<IApiIntegration, ApiIntegration>();
    }

    public void ConfigureApiIntegration(IServiceCollection services)
    {
        var client = new RestClient(Configuration.GetSection("AppSettings:ApiBaseUrl").Value);
        var request = new RestRequest($"series/api_key={Configuration.GetSection("AppSettings:ApiKey").Value}" +
            $"&series_id={Configuration.GetSection("AppSettings:SeriesId").Value}");
        services.AddTransient<IApiIntegration>(c => new ApiIntegration(client, request));
    }
}