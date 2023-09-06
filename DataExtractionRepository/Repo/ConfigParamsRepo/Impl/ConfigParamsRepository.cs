using DataExtractionAWSData.Context;
using DataExtractionDomain.Entities;
using DataExtractionRepository.Core.Generic.Impl;
using DataExtractionRepository.Repo.ConfigParamsRepo.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository.Repo.ConfigParamsRepo.Impl
{
    public class ConfigParamsRepository : GenericRepositoryAsync<tblConfigParams>, IConfigParamsRepository
    {
        private readonly DbSet<tblConfigParams> _tblConfigParams;
        public ConfigParamsRepository(DataExtractionDbContext dbContext) : base(dbContext)
        {
            _tblConfigParams = dbContext.Set<tblConfigParams>();
        }
        public async Task<List<tblConfigParams>> AllAsync()
        {
            return await _tblConfigParams.AsNoTracking().ToListAsync();
        }
        public async Task<List<tblConfigParams>> GetByConfigParamsValName(string name)
        {
            return await _tblConfigParams.AsNoTracking().Where(x => x.configParamName == name).ToListAsync();
        }
    }
}
