using PublicAPI.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.ApiModels
{
    public class UnicornToUpdateAPIModel
    {
        public HornType HornType { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSold { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
    }
}
