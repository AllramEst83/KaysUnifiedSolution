
using PublicAPI.ApiModels;
using PublicAPI.Data;
using PublicAPI.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PublicAPI.Interface
{
    public interface IHttpRepository
    {
        Task<List<UnicornApiModel>> GetAllUnicorns(CancellationToken cancellationToken);
        Task<UnicornApiModel> GetUnicornById(Guid id);
        Task<T> GenericHttpGet<T>(HttpParameters httpParameters);
        Task<UnicornApiModel> PutStreamAsync(object content, CancellationToken cancellationToken);
        Task<UnicornApiModel> PostStreamAsync(object content, CancellationToken cancellationToken);
    }
}
