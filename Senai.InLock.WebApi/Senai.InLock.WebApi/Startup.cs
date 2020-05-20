using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Senai.InLock.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddAuthentication(op =>
                {
                    op.DefaultAuthenticateScheme = "JwtBearer";
                    op.DefaultChallengeScheme = "JwtBearer";
                }
            ).AddJwtBearer("JwtBearer", op =>
                {
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao")),
                        ClockSkew = TimeSpan.FromHours(2),
                        ValidIssuer = "InLock.WebApi",
                        ValidAudience = "InLock.WebApi"
                    };
                }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API InLock Game",
                    Description = "Documentação da Api do Projeto InLock Game",
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Copie 'Bearer {token}",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                c.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy"); 

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "InLock Game V1");
                x.DocumentTitle = "API InLock Game";
            });

            app.UseMvc()
;        }
    }
}
