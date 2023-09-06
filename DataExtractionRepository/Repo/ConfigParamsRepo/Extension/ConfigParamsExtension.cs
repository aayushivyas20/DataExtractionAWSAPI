using DataExtractionRepository.Repo.ConfigParamsRepo.Impl;
using DataExtractionRepository.Repo.ConfigParamsRepo.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository.Repo.ConfigParamsRepo.Extension
{
    public class ConfigParamsExtension
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IConfigParamsRepository, ConfigParamsRepository>();
        }
    }
}
