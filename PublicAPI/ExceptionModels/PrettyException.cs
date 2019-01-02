using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Exception
{
    public class PrettyException
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
