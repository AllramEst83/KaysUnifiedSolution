using FirstLineAPI.Data;
using FirstLineAPI.Interfaces;
using FirstLineAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineAPI.Repository
{
    public class FirstLineService : IFirstLineService
    {

        public FirstLineService()
        {
        }

        public List<Unicorn> GetWelcomeMessage()
        {
            if (MockData.ListOfMockMessages == null)
            {
                MockData.ListOfMockMessages = MockData.GenerateModkData();
            }
            return MockData.ListOfMockMessages;
        }

        public Unicorn GetWelomeMessageById(Guid id)
        {
            //Guid messageId;
            //if (!Guid.TryParse(id, out messageId))
            //{

            //}

            return MockData.ListOfMockMessages.FirstOrDefault(x => x.Id == id);
        }

        public bool IfMessageExists(Guid messageId)
        {
            return MockData.ListOfMockMessages.Any(x => x.Id == messageId);
        }
    }
}
