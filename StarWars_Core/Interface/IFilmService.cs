using StarWars_Core.Common;
using StarWars_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars_Core.Interface
{
    public interface  IFilmService
    {
        Task<ApiResponse<FilmModel>> GetFilmById(int id);
    }
}
