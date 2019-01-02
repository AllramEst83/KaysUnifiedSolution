using DataBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Interfaces
{
    public interface IUnicornRepository
    {
        Task<bool> UnicornsExist();
        Task<List<Unicorn>> GetAllUnicorns();
        Task<Unicorn> GetUnicornByGuid(Guid id);
        Task<List<HornType>> GetAllHornTypes();
        Task<HornType> GetHornTypeByGuid(Guid id);
        Task<bool> UnicornExistsById(Guid id);
        Task<Unicorn> AddUnicorn(Unicorn unicornToAdd);
        Task<bool> HornTypesExist();
        Task<bool> HornTypeExistsById(Guid id);
        Task<Unicorn> UpdateUnicorn(Unicorn unicornToUpdate);
    }
}
