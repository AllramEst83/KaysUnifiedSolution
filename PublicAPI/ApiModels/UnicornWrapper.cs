
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.ApiModels
{
    public class UnicornWrapper
    {
        public int UnicornAmount { get; set; }
        public IEnumerable<UnicornApiModel> Unicorns { get; set; }
    }
}
