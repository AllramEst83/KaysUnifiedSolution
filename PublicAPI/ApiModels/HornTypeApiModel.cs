using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.ApiModels
{
    public class HornTypeApiModel
    {
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "decoration")]
        public string Decoration { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string Material { get; set; }
    }
}
