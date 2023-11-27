using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Application.Interfaces;
using TrincaChurras.Application.Services;
using TrincaChurras.Domain.Interfaces.Repositories;
using TrincaChurras.Domain.Interfaces.Services;
using TrincaChurras.Domain.Services;
using TrincaChurras.Infra.Data.Repositories;

namespace TrincaChurras.Infra.IoC
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            svcCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            svcCollection.AddScoped<IChurrasApplication, ChurrasApplication>();
            svcCollection.AddScoped<IPersonApplication, PersonApplication>();

            svcCollection.AddScoped<IChurrasService, ChurrasService>();
            svcCollection.AddScoped<IPersonService, PersonService>();

            svcCollection.AddScoped<IChurrasRepository, ChurrasRepository>();
            svcCollection.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
