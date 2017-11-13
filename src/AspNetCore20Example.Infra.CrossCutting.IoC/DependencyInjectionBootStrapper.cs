using AspNetCore20Example.Domain.Contatos.Interfaces;
using AspNetCore20Example.Domain.Usuarios.Interfaces;
using AutoMapper;
using AspNetCore20Example.Application.Interfaces;
using AspNetCore20Example.Application.Services;
using AspNetCore20Example.Domain.Contatos.Services;
using AspNetCore20Example.Domain.Core.Interfaces;
using AspNetCore20Example.Domain.Usuarios.Services;
using AspNetCore20Example.Infra.CrossCutting.Identity.Models;
using AspNetCore20Example.Infra.CrossCutting.Identity.Services;
using AspNetCore20Example.Infra.Data;
using AspNetCore20Example.Infra.Data.Context;
using AspNetCore20Example.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore20Example.Infra.CrossCutting.LoggerProviders.ElasticSearch;
using Microsoft.Extensions.Logging;
using AspNetCore20Example.Infra.CrossCutting.AspnetFilters;

namespace AspNetCore20Example.Infra.CrossCutting.IoC
{
    public class DependencyInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IContatoAppService, ContatoAppService>();
            services.AddScoped<IUsuarioDadosAppService, UsuarioDadosAppService>();

            //Domain
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IUsuarioDadosService, UsuarioDadosService>();

            //Infra.Data
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IUsuarioDadosRepository, UsuarioDadosRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainContext>();

            //Infra.CrossCutting.Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            //Infra.CrossCutting.Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();

            //Infra.CrossCutting.LoggerProviders
            services.AddSingleton<ESClientProvider>();
        }
    }
}
