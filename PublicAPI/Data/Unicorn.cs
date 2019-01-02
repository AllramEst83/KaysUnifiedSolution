using PublicAPI.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PublicAPI.Data
{
    [DataContract]
    public class Unicorn : Horse
    {
        [DataMember]
        public virtual HornType HornType { get; set; }
    }
}
