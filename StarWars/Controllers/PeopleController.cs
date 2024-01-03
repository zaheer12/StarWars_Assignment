using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWars_Core.Common;
using StarWars_Core.Interface;
using StarWars_Core.Service;
using StarWars_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
           
        }
        [HttpGet]
        [Route("TestPing")]
        public async Task<ApiResponse<string>> TestPing()
        {
            return await _peopleService.TestPing();
        }
        [HttpGet]
        [Route("GetPeopleById/{id}")]
        public async Task<ApiResponse<StarWarsModel>> GetPeopleById(int id)
        {
            //return new ApiResponse<string>().SetResponse(id);
            return await _peopleService.GetPeopleById(id);
        }

        [HttpGet]
        [Route("GetMultiplePeople")]
        public async Task<ApiResponse<List<StarWarsModel>>> GetMultiplePeople(int id,int id2)
        {
            //return new ApiResponse<string>().SetResponse(id);
            return await _peopleService.GetMultiplePeople();
        }
    }
}
