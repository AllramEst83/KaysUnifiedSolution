using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataBaseAPI.ApiModels;
using DataBaseAPI.Constants;
using DataBaseAPI.Interfaces;
using DataBaseAPI.Interfaces.Ser;
using DataBaseAPI.Models;
using DataBaseAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace DataBaseAPI.Controllers
{
    //TODO
    //Bygg upp en struktor av kontroller och korrekt response och exceptions till allt

    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors(HttpConstants.DataBasePolicy)]
    public class UnicornController : ControllerBase
    {
        public IUnicornService _unicornService { get; }

        public UnicornController(IUnicornService unicornService)
        {
            _unicornService = unicornService;
        }

        [HttpGet(Name = "Ping")]
        public async Task<bool> Ping()
        {
            return await _unicornService.UnicornsExist();
        }

        [HttpGet(Name = "GetAllUnicorns")]
        public async Task<ActionResult> GetAllUnicorns()
        {
            if (!await _unicornService.UnicornsExist())
            {
                return NotFound(HttpConstants.OutOfUnicorns);
            }

            List<UnicornApiModel> unicorns = await _unicornService.GetAllUnicorns();
            string serilizedUnicornsList = JsonConvert.SerializeObject(unicorns);

            return Ok(serilizedUnicornsList);
        }

        [HttpGet("{id}", Name = "GetUnicornById")]
        public async Task<ActionResult<string>> GetUnicornById(Guid id)
        {
            if (!await _unicornService.UnicornExitsById(id))
            {
                return NotFound(HttpConstants.UnicornNotFound);
            }

            UnicornApiModel unicorn = await _unicornService.GetUnicornByGuid(id);
            string serilizedUnicorn = JsonConvert.SerializeObject(unicorn);

            return Ok(serilizedUnicorn);
        }

        [HttpPost(Name = "AddUnicorn")]
        public async Task<ActionResult> AddUnicorn([FromBody] UnicornApiModel unicorn)
        {
            if (unicorn == null)
            {
                return BadRequest();
            }

            Unicorn unicornToAdd = Mapper.Map<Unicorn>(unicorn);

            Unicorn addedUnicorn = await _unicornService.AddUnicorn(unicornToAdd);

            return Ok(addedUnicorn);
        }

        [HttpGet(Name = "GetAllHornTypes")]
        public async Task<ActionResult> GetAllHornTypes()
        {
            if (!await _unicornService.HornTypesExist())
            {
                return NotFound(HttpConstants.OutOfHornTypes);
            }

            List<HornTypeApiModel> unicorns = await _unicornService.GetAllHornTypes();
            string serilizedHornTypesList = JsonConvert.SerializeObject(unicorns);

            return Ok(serilizedHornTypesList);
        }

        [HttpPut(Name = "UpdateUnicorn")]
        public async Task<ActionResult> UpdateUnicorn([FromBody] UnicornApiModel unicorn)
        {
            if (unicorn == null)
            {
                return BadRequest();
            }

            if (!await _unicornService.UnicornExitsById(unicorn.Id))
            {
                return NotFound(HttpConstants.UnicornNotFound);
            }

            Unicorn unicornToUpdate = Mapper.Map<Unicorn>(unicorn);

            Unicorn updatedUnicorn = await _unicornService.UpdateUnicorn(unicornToUpdate);

            return Ok(updatedUnicorn);
        }


        [HttpGet("{id}",Name = "GetHornTypeById")]
        public async Task<ActionResult> GetHornTypeById(Guid id)
        {
            if (!await _unicornService.HornTypeExitsById(id))
            {
                return NotFound(HttpConstants.HornTypeNotFound);
            }

            var newHornType = await _unicornService.GetHornTypeByGuid(id);

            return Ok(newHornType);

        }



    }
}