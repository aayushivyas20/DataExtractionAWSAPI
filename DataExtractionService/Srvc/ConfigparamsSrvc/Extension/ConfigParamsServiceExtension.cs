using DataExtractionService.Srvc.ConfigparamsSrvc.Impl;
using DataExtractionService.Srvc.ConfigparamsSrvc.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionService.Srvc.ConfigparamsSrvc.Extension
{
    public class ConfigParamsServiceExtension
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IConfigParamsService, ConfigParamsService>();
        }
    }
}
