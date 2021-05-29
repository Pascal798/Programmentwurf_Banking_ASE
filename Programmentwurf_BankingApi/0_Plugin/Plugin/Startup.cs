using _3_Domain.Domain.Domain_Services;
using _3_Domain.Domain.Others;
using _3_Domain.Domain.Others.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Programmentwurf_BankingApi.Plugin;
using Programmentwurf_BankingApi.Plugin.Bank;
using Programmentwurf_BankingApi.Plugin.Konto;
using Programmentwurf_BankingApi.Plugin.Transaction;
using Programmentwurf_BankingApi.Plugin.User;

namespace Programmentwurf_BankingApi
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

            services.AddDbContext<BankingContext>(opt => opt.UseInMemoryDatabase("Banking"));
            services.AddScoped<IBankingContext, BankingContext>();
            services.AddScoped<UserRepositoryImpl, UserRepositoryImpl>();
            services.AddScoped<ChangePasswordImpl, ChangePasswordImpl>();
            services.AddScoped<KontoRepositoryImpl, KontoRepositoryImpl>();
            services.AddScoped<TransactionRepositoryImpl, TransactionRepositoryImpl>();
            services.AddScoped<BankRepositoryImpl, BankRepositoryImpl>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
