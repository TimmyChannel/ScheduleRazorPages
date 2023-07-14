using Schedule.Configuration;

namespace Schedule.Extensions
{
    public static class ServiceExtensions
    {
        public static void AppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IISOptions>(options => options.ForwardClientCertificate = false);
            services.Configure<SqlServerOptions>(configuration.GetSection(nameof(SqlServerOptions)));
        }
    }
}
