﻿using PublicAPI.ApiModels;
using PublicAPI.Data;
using PublicAPI.ExceptionModels;
using PublicAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PublicAPI.Interface
{
    public interface IUnicornService
    {
        Task<string> GetAllUnicorns(CancellationToken cancellationToken);
        string PrettySerializeCustomExeption(CustomApiException exceptionObject);
        Task<string> GetUnicornByGuid(Guid id);
        string SerializeResponse<T>(T responseObject);
        Task<List<UnicornApiModel>> GetUnicornsForXml();
        Task<UnicornApiModel> AddUnicorn(CreateUnicornApiModel unicornToAdd);
        Task<string> GetAllHornTypes(CancellationToken cancellationToken);
        Task<UnicornApiModel> UpdateUnicorn(UnicornToUpdateAPIModel unicornToUpdate);
        Task<UnicornApiModel> AssignNewHornType(UnicornApiModel unicorn);
        Task<CreateUnicornApiModel> AssignNewHornTypeToNewUnicorn(CreateUnicornApiModel unicorn);
        Task<string> DeleteUnicorn(CancellationToken cancellationToken, Guid Id);
    }
}
