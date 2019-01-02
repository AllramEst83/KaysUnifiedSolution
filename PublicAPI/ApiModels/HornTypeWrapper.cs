using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.ApiModels
{
    public class HornTypeWrapper
    {
        public int HornTypeAmount { get; set; }
        public IEnumerable<HornTypeApiModel> HornTypes { get; set; }
    }
}
