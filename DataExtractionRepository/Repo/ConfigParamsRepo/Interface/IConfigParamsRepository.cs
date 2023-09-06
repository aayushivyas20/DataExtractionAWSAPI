using DataExtractionDomain.Entities;
using DataExtractionRepository.Core.Generic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository.Repo.ConfigParamsRepo.Interface
{
    public interface IConfigParamsRepository : IGenericRepositoryAsync<tblConfigParams>
    {
        Task<List<tblConfigParams>> AllAsync();
        Task<List<tblConfigParams>> GetByConfigParamsValName(string name);
    }
}
