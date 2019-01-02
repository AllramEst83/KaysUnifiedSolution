
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstLineAPI.Interfaces;
using FirstLineAPI.Models;
using FirstLineAPI.Models.WelcomeMessage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstLineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstLineController : ControllerBase
    {
        public IFirstLineService _firstLineService { get; }
        public FirstLineController(IFirstLineService firstLineService)
        {
            _firstLineService = firstLineService;
        }

        //--
        [HttpGet("GetAllMessages")]
        public ActionResult<List<Unicorn>> Get()
        {
            return _firstLineService.GetWelcomeMessage();
        }

        [HttpGet("GetById/{id}", Name = "GetById")]
        public ActionResult<Unicorn> GetById(Guid id)
        {
            if (!_firstLineService.IfMessageExists(id))
            {
                ModelState.AddModelError(nameof(UnicornErrorMessage), "Message does not exists, Please input a valid id");

                return new MessageNotFound(ModelState);

            }

            return Ok(_firstLineService.GetWelomeMessageById(id));
        }


        [HttpPut("UpdateById/{id}", Name = "UpdateById")]
        public ActionResult<Unicorn> UpdateById(Guid id, [FromBody] Unicorn messageToUpdate)
        {
            if (messageToUpdate == null)
            {
                return BadRequest();
            }

            return new Unicorn();
        }



    }
}