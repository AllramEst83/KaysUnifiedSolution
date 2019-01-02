using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PublicAPI.Repository
{
    public class HttpParameters
    {
        public string RequestUrl { get; set; }
        public CancellationToken cancellationToken { get; set; }
        public Guid Id { get; set; }
    }
}
