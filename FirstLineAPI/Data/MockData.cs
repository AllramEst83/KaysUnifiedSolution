using FirstLineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineAPI.Data
{
    public static class MockData
    {
        public static List<Unicorn> ListOfMockMessages { get; set; }
        public static DateTime ReturnCurrentDate() => DateTime.Now;

        public static List<Unicorn> GenerateModkData()
        {
            return new List<Unicorn>()
            {
                new Unicorn(){Id = Guid.NewGuid(), CurrentDate = ReturnCurrentDate(), WelcomeMessage = "Welcome Message Placeholder"},
                new Unicorn(){Id = Guid.NewGuid(), CurrentDate = ReturnCurrentDate(), WelcomeMessage = "Welcome Message Placeholder"},
                new Unicorn(){Id = Guid.NewGuid(), CurrentDate = ReturnCurrentDate(), WelcomeMessage = "Welcome Message Placeholder"},
                new Unicorn(){Id = Guid.NewGuid(), CurrentDate = ReturnCurrentDate(), WelcomeMessage = "Welcome Message Placeholder"},
                new Unicorn(){Id = Guid.NewGuid(), CurrentDate = ReturnCurrentDate(), WelcomeMessage = "Welcome Message Placeholder"},
            };
        }
    }
}
