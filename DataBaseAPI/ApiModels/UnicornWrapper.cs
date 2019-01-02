using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.ApiModels
{
    public class UnicornWrapper
    {
        public IEnumerable<UnicornApiModel> Unicorns { get; set; }
        public int UnicornAmount { get; set; }
    }
}
