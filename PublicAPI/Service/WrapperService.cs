
using PublicAPI.ApiModels;
using PublicAPI.Interfaces.Ser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Services
{
 

    public class WrapperService : IWrapperService
    {

        public WrapperService()
        {

        }

        public List<UnicornApiModel> WrapSingelUncornInList(UnicornApiModel unicorn)
        {
            var listofUnicorns = new List<UnicornApiModel>(1)
            {
                unicorn
            };

            return listofUnicorns;
        }

        public UnicornWrapper WrappifyUnicorns(IEnumerable<UnicornApiModel> listOfUnicorns)
        {
            UnicornWrapper wrappedUnicorns = new UnicornWrapper()
            {
                UnicornAmount = listOfUnicorns.Count(),
                Unicorns = listOfUnicorns               
            };

            return wrappedUnicorns;
        }

        public HornTypeWrapper WrappifyHornTypes(IEnumerable<HornTypeApiModel> listOfHornTypes)
        {
            HornTypeWrapper wrappedHornTypes = new HornTypeWrapper()
            {
                HornTypeAmount = listOfHornTypes.Count(),
                HornTypes = listOfHornTypes
            };

            return wrappedHornTypes;
        }
    }
}
