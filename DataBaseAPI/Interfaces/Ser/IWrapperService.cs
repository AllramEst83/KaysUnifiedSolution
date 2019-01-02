using DataBaseAPI.ApiModels;
using DataBaseAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Interfaces.Ser
{
    public interface IWrapperService
    {
        UnicornWrapper Wrappify(IEnumerable<UnicornApiModel> listOfUnicorns);
    }
}
