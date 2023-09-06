using DataExtractionRepository.Core.Generic.Impl;
using DataExtractionRepository.Core.Generic.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository.Core.Generic.Extension
{
    public class GenericExtension
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        }
    }
}
