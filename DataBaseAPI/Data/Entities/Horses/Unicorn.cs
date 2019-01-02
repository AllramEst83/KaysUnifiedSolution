using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.Models
{
    public class Unicorn : Horse
    {
        [ForeignKey("HornTypesId")]
        public virtual HornType HornType { get; set; }

    }
}
