

using PublicAPI.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Interfaces.Ser
{
    public interface IWrapperService
    {
        UnicornWrapper WrappifyUnicorns(IEnumerable<UnicornApiModel> listOfUnicorns);
        HornTypeWrapper WrappifyHornTypes(IEnumerable<HornTypeApiModel> listOfHornTypes);
        List<UnicornApiModel> WrapSingelUncornInList(UnicornApiModel unicorn);
    }
}
