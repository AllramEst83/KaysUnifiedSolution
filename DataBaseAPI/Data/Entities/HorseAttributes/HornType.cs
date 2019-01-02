using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Models
{
    public class HornType
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Decoration { get; set; }
        public string Material { get; set; }
    }
}
