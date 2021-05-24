using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Programmentwurf_BankingApi._0Plugin.Bank;
using Programmentwurf_BankingApi._1Adapter.Bank;
using Programmentwurf_BankingApi._3Domain.Others;
using Programmentwurf_BankingApi.Adapter.Konto;
using Programmentwurf_BankingApi.Adapter.Transaction;
using Programmentwurf_BankingApi.Adapter.User;
using Programmentwurf_BankingApi.Plugin;
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
            services.AddScoped<UserRepositoryBridge, UserRepositoryBridge>();
            services.AddScoped<UserToUserResourceMapper, UserToUserResourceMapper>();
            services.AddScoped<KontoRepositoryBridge, KontoRepositoryBridge>();
            services.AddScoped<KontoToKontoResourceMapper, KontoToKontoResourceMapper>();
            services.AddScoped<TransactionRepositoryBridge, TransactionRepositoryBridge>();
            services.AddScoped<TransactionToTransactionResourceMapper, TransactionToTransactionResourceMapper>();
            services.AddScoped<BankRepositoryBridge, BankRepositoryBridge>();
            services.AddScoped<BankToBankResourceMapper, BankToBankResourceMapper>();
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
