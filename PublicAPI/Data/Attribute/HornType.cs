using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PublicAPI.Data.Attribute
{
    [DataContract]
    public class HornType
    {
        [DataMember]       
        public Guid Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "decoration")]
        public string Decoration { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "material")]
        public string Material { get; set; }
    }
}
