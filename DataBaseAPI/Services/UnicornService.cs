using AutoMapper;
using DataBaseAPI.ApiModels;
using DataBaseAPI.Interfaces;
using DataBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Services
{
    public class UnicornService : IUnicornService
    {
        public IUnicornRepository _unicornRepo { get; }

        public UnicornService(IUnicornRepository UnicornRepo)
        {
            _unicornRepo = UnicornRepo;
        }

        public async Task<List<UnicornApiModel>> GetAllUnicorns()
        {
            var repsoitoryResponse = await _unicornRepo.GetAllUnicorns();

            return Mapper.Map<List<UnicornApiModel>>(repsoitoryResponse);
        }
        public async Task<List<HornTypeApiModel>> GetAllHornTypes() => Mapper.Map<List<HornTypeApiModel>>(await _unicornRepo.GetAllHornTypes());

        public async Task<UnicornApiModel> GetUnicornByGuid(Guid id) => Mapper.Map<UnicornApiModel>(await _unicornRepo.GetUnicornByGuid(id));

        public async Task<HornTypeApiModel> GetHornTypeByGuid(Guid id) => Mapper.Map<HornTypeApiModel>(await _unicornRepo.GetHornTypeByGuid(id));

        public async Task<bool> UnicornsExist() => await _unicornRepo.UnicornsExist();

        public async Task<bool> UnicornExitsById(Guid id) => await _unicornRepo.UnicornExistsById(id);

        public async Task<bool> HornTypesExist() => await _unicornRepo.HornTypesExist();

        public async Task<bool> HornTypeExitsById(Guid id) => await _unicornRepo.HornTypeExistsById(id);

        public async Task<Unicorn> AddUnicorn(Unicorn unicornToAdd)
        {
            Unicorn addedUnicorn = await _unicornRepo.AddUnicorn(unicornToAdd);

            return addedUnicorn;
        }

        public async Task<UnicornApiModel> UpdateUnicorn(Unicorn unicornToUpdate)
        {
            Unicorn updatedUnicorn = await _unicornRepo.UpdateUnicorn(unicornToUpdate);

            return Mapper.Map<UnicornApiModel>(updatedUnicorn);
        }

        public async Task<UnicornApiModel> DeleteUnicorn(Guid Id)
        {
            Unicorn deletedUnicorn = await _unicornRepo.DeleteUnicorn(Id);
            UnicornApiModel unicornToSend = Mapper.Map<UnicornApiModel>(deletedUnicorn);

            return unicornToSend;
        }

    }
}
