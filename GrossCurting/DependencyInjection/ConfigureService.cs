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
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IProjetoService, ProjetoService>();
            serviceColletion.AddTransient<ITarefaService, TarefaService>();
        }
    }
}
