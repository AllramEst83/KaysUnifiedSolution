using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicAPI.ApiModels;
using PublicAPI.Constants;
using PublicAPI.Data;
using PublicAPI.Interface;
using PublicAPI.Interfaces.Ser;

namespace PublicAPI.Controllers
{
    //TODO:
    //Bygg anrops struktur och olika responses om tex objekt inte finns

    [Route("api/[controller]/[action]")]
    [ApiController]
    //Activate CORS on the controller
    [EnableCors(HttpConstants.PublicReact)]
    public class PublicUnicornController : ControllerBase
    {
        public IUnicornService _unicornService { get; }
        public IWrapperService _wrapperService { get; }

        public PublicUnicornController(IUnicornService unicornService, IWrapperService wrapperService)
        {
            _unicornService = unicornService;
            _wrapperService = wrapperService;
        }


        [HttpGet(Name = "GetUnicorns")]
        //[Produces("application/json")] <--Bygg ModelState Error Först
        public async Task<ActionResult<string>> GetUnicorns()
        {
            //TODO: Läs om cancellation token
            string wrappedAndSerializedUnicorns = await _unicornService.GetAllUnicorns(CancellationToken.None);

            return Ok(wrappedAndSerializedUnicorns);
        }

        [HttpGet("{id}", Name = "GetUnicornById")]
        //[Produces("application/json")]  <--Bygg ModelState Error Först
        public async Task<ActionResult<string>> GetUnicornById(Guid id)
        {
            string wrappedAndSerializedUnicorn = await _unicornService.GetUnicornByGuid(id);

            return Ok(wrappedAndSerializedUnicorn);
        }

        [HttpPost(Name = "AddUnicorn")]
        public async Task<ActionResult> AddUnicorn([FromBody] UnicornApiModel unicornToAdd)
        {
            if (unicornToAdd == null)
            {
                return BadRequest("Please post the correct data");
            }

            UnicornToAddAPIModel unicorn = Mapper.Map<UnicornToAddAPIModel>(unicornToAdd);

            UnicornApiModel addedUnicorn = await _unicornService.AddUnicorn(unicorn);

            return Ok(addedUnicorn);
        }

        [HttpGet(Name = "GetAllHornTypes")]
        public async Task<ActionResult> GetAllHornTypes()
        {
            string wrappedAndSerializedHornTypes = await _unicornService.GetAllHornTypes(CancellationToken.None);

            return Ok(wrappedAndSerializedHornTypes);
        }

        [HttpPut(Name = "UpdateUnicorn")]
        public async Task<ActionResult> UpdateUnicorn([FromBody]UnicornApiModel unicornToUpdate)
        {
            if (unicornToUpdate == null)
            {
                return BadRequest("Please post the correct data");
            }

          unicornToUpdate = 
                    await _unicornService.AssignNewHornType(unicornToUpdate);
            

            UnicornToUpdateAPIModel unicorn = Mapper.Map<UnicornToUpdateAPIModel>(unicornToUpdate);

            UnicornApiModel updatedUnicorn = await _unicornService.UpdateUnicorn(unicorn);

            return Ok(updatedUnicorn);
        }

        [HttpGet]
        [Produces("application/xml")]
        public async Task<ActionResult<List<UnicornApiModel>>> GetUnicornXml([FromHeader(Name = "Content-type")] string mediaType)
        {

            if (mediaType == "application/xml")
            {
                return await _unicornService.GetUnicornsForXml();
            }

            return BadRequest("The correct mediatype is missing.");
        }


    }
}