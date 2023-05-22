using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace CrossCutting.IoC
{
    public static class DenpendecyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaService, EmpresaService>();

            return services;
        }

        public static IServiceCollection AddCorsCustom(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Mypolicy",
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                          .AllowAnyMethod()
                                          .WithHeaders(
                                              HeaderNames.ContentType,
                                              HeaderNames.Authorization);
                                  });
            });


            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidAudience = configuration["TokenConfiguration:Audience"],
                     ValidIssuer = configuration["TokenConfiguration:Issuer"],
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
                 });

            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
            ,IConfiguration configuration)
        {

            var connectionString = configuration["ConnectionStrings:MsEmpresa"];

            services.AddDbContext<MsContext>(opt =>
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                b => b.MigrationsAssembly(typeof(MsContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return services;
        }
    }
}
