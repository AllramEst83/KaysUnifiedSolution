using DataBaseAPI.ApiModels;
using DataBaseAPI.Interfaces.Ser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Services
{
 

    public class WrapperService : IWrapperService
    {

        public WrapperService()
        {

        }

        public UnicornWrapper Wrappify(IEnumerable<UnicornApiModel> listOfUnicorns)
        {
            UnicornWrapper wrappedUnicorns = new UnicornWrapper()
            {
                Unicorns = listOfUnicorns,
                UnicornAmount = listOfUnicorns.Count()
            };

            return wrappedUnicorns;
        }

    }
}
