using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Application.UnitOfWork; 
using AspNetCoreRateLimit; 
using Domain.Interfaces; 

namespace API.Extension; 

    public static class ApplicationServiceExtensions 
    { 
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options => 
            { 
                options.AddPolicy("CorsPolicy", builder => 
            { 
                    builder.AllowAnyOrigin()    //WithOrigins("https://domain.com") 
                    .AllowAnyMethod()       //WithMethods("GET","POST") 
                    .AllowAnyHeader();     //WithHeaders("accept","content-type") 
            }); 
        }); 
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Limit = 100,
                        Period = "10s"
                    },
                };
            });
        }
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
