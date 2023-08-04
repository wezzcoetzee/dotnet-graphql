namespace BooksApi.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddCommonConfigurationProviders(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureHostConfiguration(cfg => { cfg.AddEnvironmentVariables("Books_"); });

        hostBuilder.ConfigureAppConfiguration((context, config) =>
        {
            if (context.HostingEnvironment.IsDevelopment())
                config.AddJsonFile($"appsettings.{Environments.Development}.json", optional: true);
        });

        return hostBuilder;
    }
}