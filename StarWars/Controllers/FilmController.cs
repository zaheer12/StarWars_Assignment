using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWars_Core.Common;
using StarWars_Core.Interface;
using StarWars_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        [HttpGet]
        [Route("GetFilmById/{id}")]
        public async Task<ApiResponse<FilmModel>> GetFilmById(int id)
        {
            return await _filmService.GetFilmById(id);
        }
    }
}
