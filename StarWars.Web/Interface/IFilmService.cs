using StarWars.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StarWars.Web.Common.ResponseHelper;

namespace StarWars.Web.Interface
{
    public interface IFilmService
    {
        Task<ApiResponse<FilmModel>> GetFilmById(string id);
    }
}
