using DataExtractionRepository.Core.Generic.Extension;
using DataExtractionRepository.Repo.ConfigParamsRepo.Extension;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository
{
    public class RepositoryRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            GenericExtension.RegisterServices(services);
            ConfigParamsExtension.RegisterServices(services);
        }
    }
}
