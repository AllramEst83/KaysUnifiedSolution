using DataBaseAPI.ApiModels;
using DataBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Interfaces
{
    public interface IUnicornService
    {
        Task<List<UnicornApiModel>> GetAllUnicorns();
        Task<List<HornTypeApiModel>> GetAllHornTypes();
        Task<UnicornApiModel> GetUnicornByGuid(Guid id);
        Task<HornTypeApiModel> GetHornTypeByGuid(Guid id);
        Task<bool> UnicornsExist();
        Task<bool> UnicornExitsById(Guid id);
        Task<Unicorn> AddUnicorn(Unicorn unicornToAdd);
        Task<bool> HornTypesExist();
        Task<bool> HornTypeExitsById(Guid id);
        Task<Unicorn> UpdateUnicorn(Unicorn unicornToUpdate);
    }
}
