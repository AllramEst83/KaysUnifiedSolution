using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PublicAPI.ApiModels;
using PublicAPI.Exception;
using PublicAPI.ExceptionModels;
using PublicAPI.Interface;
using PublicAPI.Interfaces.Ser;
using PublicAPI.Repository;
using PublicAPI.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PublicAPI.Constants;
using System.Net.Http;

namespace PublicAPI.Service
{
    public class UnicornService : IUnicornService
    {
        public IHttpRepository _httpRepository { get; }
        public IConfiguration _configuration { get; }
        public IWrapperService _wrapperService { get; }

        public UnicornService(IHttpRepository httpRepository,
            IConfiguration configuration,
            IWrapperService wrapperService)
        {
            _httpRepository = httpRepository;
            _configuration = configuration;
            _wrapperService = wrapperService;
        }

        public async Task<string> GetAllUnicorns(CancellationToken cancellationToken)
        {
            string getUnicornsUrl = _configuration.GetSection("ApiURl")["GetAllUnicornsUrl"];

            HttpParameters httpParameters = new HttpParameters()
            {
                RequestUrl = getUnicornsUrl,
                cancellationToken = cancellationToken
            };

            string responseString = String.Empty;
            try
            {
                var response = await _httpRepository.GenericHttpGet<List<UnicornApiModel>>(httpParameters);
                UnicornWrapper wrappedUnicorns = _wrapperService.WrappifyUnicorns(response);
                responseString = SerializeResponse(wrappedUnicorns);
            }
            catch (CustomApiException ex)
            {

                responseString = PrettySerializeCustomExeption(ex);
            }

            return responseString;
        }

        public async Task<string> GetUnicornByGuid(Guid id)
        {
            string getUnicornsUrl = _configuration.GetSection("ApiURl")["GetUnicornById"];

            HttpParameters httpParameters = new HttpParameters()
            {
                RequestUrl = getUnicornsUrl,
                Id = id
            };

            string responseString = String.Empty;
            try
            {
                UnicornApiModel response = await _httpRepository.GenericHttpGet<UnicornApiModel>(httpParameters);

                List<UnicornApiModel> preparedUnicorn = _wrapperService.WrapSingelUncornInList(response);
                UnicornWrapper wrappedUnicorn = _wrapperService.WrappifyUnicorns(preparedUnicorn);

                responseString = SerializeResponse(wrappedUnicorn);
            }
            catch (CustomApiException ex)
            {
                responseString = PrettySerializeCustomExeption(ex);
            }

            return responseString;
        }

        public async Task<HornTypeApiModel> GetHornTypeByGuid(Guid hornTypeId)
        {
            string getUnicornsUrl = _configuration.GetSection("ApiURl")["GetHornTypeById"];

            HttpParameters httpParameters = new HttpParameters()
            {
                RequestUrl = getUnicornsUrl,
                Id = hornTypeId
            };

            HornTypeApiModel response = new HornTypeApiModel();
            try
            {
                response = await _httpRepository.GenericHttpGet<HornTypeApiModel>(httpParameters);
            }
            catch (CustomApiException ex)
            {
                throw;
            }

            return response;
        }

        public string SerializeResponse<T>(T responseObject)
        {
            return JsonConvert.SerializeObject(responseObject);
        }

        public string PrettySerializeCustomExeption(CustomApiException exceptionObject)
        {
            PrettyException objectToSerialize = new PrettyException()
            {
                Message = exceptionObject.Content,
                StatusCode = exceptionObject.StatusCode
            };

            return SerializeResponse(objectToSerialize);
        }

        public async Task<List<UnicornApiModel>> GetUnicornsForXml() => await _httpRepository.GetAllUnicorns(CancellationToken.None);

        public async Task<UnicornApiModel> AddUnicorn(CreateUnicornApiModel unicornToAdd)
        {
            string addUnicornUrl = _configuration.GetSection("ApiURl")["AddUnicorn"];

            HttpParameters parameters = new HttpParameters()
            {
                Content = unicornToAdd,
                cancellationToken = CancellationToken.None,
                HttpVerb = HttpMethod.Post,
                RequestUrl = addUnicornUrl
            };

            UnicornApiModel addedUnicorn = await _httpRepository.PostStreamAsyncContent(parameters);

            return addedUnicorn;
        }

        public async Task<UnicornApiModel> UpdateUnicorn(UnicornToUpdateAPIModel unicornToUpdate)
        {

            UnicornApiModel addedUnicorn = await _httpRepository.PutStreamAsync(unicornToUpdate, CancellationToken.None);

            return addedUnicorn;
        }


        public async Task<string> GetAllHornTypes(CancellationToken cancellationToken)
        {
            string getHornTypeUrl = _configuration.GetSection("ApiURl")["GetAllHornTypes"];

            HttpParameters httpParameters = new HttpParameters()
            {
                RequestUrl = getHornTypeUrl,
                cancellationToken = cancellationToken
            };

            string responseString = String.Empty;

            try
            {
                var response = await _httpRepository.GenericHttpGet<List<HornTypeApiModel>>(httpParameters);
                HornTypeWrapper wrappedUnicorns = _wrapperService.WrappifyHornTypes(response);
                responseString = SerializeResponse(wrappedUnicorns);
            }
            catch (CustomApiException ex)
            {

                responseString = PrettySerializeCustomExeption(ex);
            }

            return responseString;
        }

        public async Task<UnicornApiModel> AssignNewHornType(UnicornApiModel unicorn)
        {
            HornTypeApiModel newHorntype = await GetHornTypeByGuid(unicorn.HornType.Id);

            var hornType = Mapper.Map<HornType>(newHorntype);

            UnicornApiModel updatedUnicorn = new UnicornApiModel()
            {
                Id = unicorn.Id,
                Name = unicorn.Name,
                Breed = unicorn.Breed,
                Description = unicorn.Description,
                DateOfBirth = unicorn.DateOfBirth,
                IsDeleted = unicorn.IsDeleted,
                IsSold = unicorn.IsSold,
                Origin = unicorn.Origin,
                HornType = hornType
            };

            return updatedUnicorn;
        }

        public async Task<CreateUnicornApiModel> AssignNewHornTypeToNewUnicorn(CreateUnicornApiModel unicorn)
        {
            HornTypeApiModel newHorntype = await GetHornTypeByGuid(unicorn.HornType.Id);

            var hornType = Mapper.Map<HornType>(newHorntype);

            CreateUnicornApiModel updatedUnicorn = new CreateUnicornApiModel()
            {
                Name = unicorn.Name,
                Breed = unicorn.Breed,
                Description = unicorn.Description,
                DateOfBirth = unicorn.DateOfBirth,
                IsDeleted = unicorn.IsDeleted,
                IsSold = unicorn.IsSold,
                Origin = unicorn.Origin,
                HornType = hornType
            };

            return updatedUnicorn;
        }


        public async Task<string> DeleteUnicorn(CancellationToken cancellationToken, Guid Id)
        {
            string deleteUnicornUrl = _configuration.GetSection("ApiURl")["DeleteUnicorn"];

            HttpParameters httpParameters = new HttpParameters()
            {
                RequestUrl = deleteUnicornUrl,
                cancellationToken = cancellationToken,
                HttpVerb = HttpMethod.Delete,
                Id = Id,
                Content = null

            };

            string responseString = String.Empty;
            try
            {
                UnicornApiModel deletedUnicorn = await _httpRepository.PostStreamAsyncQueryString<UnicornApiModel>(httpParameters);
                responseString = JsonConvert.SerializeObject(deletedUnicorn);
            }
            catch (CustomApiException ex)
            {

                responseString = PrettySerializeCustomExeption(ex);
            }


            return responseString;
        }


    }


}
