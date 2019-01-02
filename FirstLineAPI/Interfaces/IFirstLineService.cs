using FirstLineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineAPI.Interfaces
{
    public interface IFirstLineService
    {
        List<Unicorn> GetWelcomeMessage();
        Unicorn GetWelomeMessageById(Guid id);
        bool IfMessageExists(Guid messageId);
    }
}
