using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BuildersAPI
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_MyOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            var _AppConfig = Configuration.GetSection("AppConfig").Get<AppConfig>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                builder =>
                {
                    builder.SetIsOriginAllowed(isOriginAllowed: _ => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });

            services.AddSingleton<IAppConfig>(Configuration.GetSection("AppConfig").Get<AppConfig>());
            services.AddSingleton<IMongoClient>(new MongoClient(_AppConfig.MongoDB));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseCors(MyAllowSpecificOrigins);
            app.UseCorsMiddleware();
            app.UseMiddleware<WebAuth>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var sb = new StringBuilder();
                    sb.Append("API is running smoothly..." + Environment.NewLine);
                    sb.Append(string.Format("Product: v{0}", GetType().Assembly.GetName().Version.ToString()));
                    sb.Append(Environment.NewLine);
                    sb.Append("############################" + Environment.NewLine);
                    sb.Append("#                          #" + Environment.NewLine);
                    sb.Append(string.Format("#  Copyright - {0}  #", DateTime.Now.ToString("yyyy-MM-dd")) + Environment.NewLine);
                    sb.Append("#                          #" + Environment.NewLine);
                    sb.Append("############################");

                    await context.Response.WriteAsync(sb.ToString());
                });

                endpoints.MapControllers();
            });
        }
    }
}