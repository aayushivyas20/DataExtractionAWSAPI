using DataExtractionService.Srvc.ConfigparamsSrvc.Extension;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionService.Srvc
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            ConfigParamsServiceExtension.RegisterServices(services);
        }
    }
}
