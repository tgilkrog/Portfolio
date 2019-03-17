using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            string serviceName = Configuration.GetSection("AppSettings")["ServiceName"];
            string serviceKey = Configuration.GetSection("AppSettings")["ServiceKey"];
            string connectionString = Configuration.GetConnectionString("SqlServerConnectionString");

            services.AddTransient<ICustomerService>(gs => new CustomerService(new CustomerRepository(connectionString)));
            services.AddTransient<IDrinkService>(gs => new DrinkService(new DrinkRepository(connectionString)));
            services.AddTransient<IUserService>(gs => new UserService(new UserRepository(connectionString)));
            services.AddTransient <ISubscriptionService>(gs => new SubscriptionService(new SubscriptionRepository(connectionString)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());

            app.UseMvc();
        }
    }
}
