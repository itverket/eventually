using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure
{
    public static class WebApiConfiguration
    {
        public static void ConfigureWebApi(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                     corsBuilder => corsBuilder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc();
      
            services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
            {
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });
        }
        
    }
}