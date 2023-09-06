using DataExtractionAWSData.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DataExtractionAWSData
{
    public static class ContextRegistration
    {
        public static void ContextServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataExtractionDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
        }
    }
}
