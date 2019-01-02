using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineAPI.Models
{
    public class Unicorn
    {
        public Guid Id { get; set; }
        public string WelcomeMessage { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
