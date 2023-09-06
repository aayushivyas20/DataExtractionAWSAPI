using DataExtractionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionAWSData.Context
{
    public class DataExtractionDbContext : DbContext
    {
        public DataExtractionDbContext(DbContextOptions<DataExtractionDbContext> options) : base(options)
        {
        }
        public DbSet<tblConfigParams> tblConfigParams { get; set; }
    }
}
