using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schedule.Services;
using Schedule.Services.Repository;
using System.Data;
using System.Data.SqlClient;


namespace Schedule
{

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Добавляем поддержку базы данных
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(_configuration.GetConnectionString("DefaultConnection")));

            // Регистрируем репозиторий и сервис
            services.AddScoped<IScheduleEventRepository, ScheduleEventRepository>();
            services.AddScoped<ScheduleEventService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
            return connection;
        }
    }
}

