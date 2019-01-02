
using Newtonsoft.Json;
using PublicAPI.Data.Attribute;
using PublicAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.ApiModels
{
    public class UnicornApiModel
    {      
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "horntype")]
        public HornType HornType { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "breed")]
        public string Breed { get; set; }

        [JsonProperty(PropertyName = "dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

        public bool IsDeleted { get; set; }
        
        public bool IsSold { get; set; }
    }
}
