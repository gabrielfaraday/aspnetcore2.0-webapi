using AspNetCore20Example.Infra.CrossCutting.LoggerProviders.ElasticSearch;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore20Example.Infra.CrossCutting.LoggerProviders
{
    public static class LoggerProvidersExtensions
    {
        public static ILoggerFactory AddElasticSearchLogger(this ILoggerFactory factory, IServiceProvider serviceProvider)
        {
            factory.AddProvider(new ESLoggerProvider(serviceProvider));
            return factory;
        }
    }
}
