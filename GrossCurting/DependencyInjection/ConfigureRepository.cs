using Data.Context;
using Data.Context.Interfaces;
using Data.Repositories;
using Domin.Interfaces.Repositories;
using Domin.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrossCurting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IProjetoRepository, ProjetoRepository>();
            serviceColletion.AddTransient<ITarefaRepository, TarefaRepository>();
            serviceColletion.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
