using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Models
{
    public class Horse
    {
        [Key]
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
