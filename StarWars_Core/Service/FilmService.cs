using Newtonsoft.Json;
using StarWars_Core.Common;
using StarWars_Core.Constants;
using StarWars_Core.Interface;
using StarWars_Data.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWars_Core.Service
{

    public class FilmService : IFilmService
    {
        //private readonly IFilmRepository _FilmRepository;
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            //_FilmRepository = FilmRepository;
            _httpClient = httpClient;
        }

        
        public async Task<ApiResponse<FilmModel?>> GetFilmById(int id)
        {
            var result = await GetFilm(id);
            if (result != null)
            {
                var data = ResponseHelper.GetResponse(result);
                return data;
            }
            else
            {
                return ResponseHelper.GetResponse(result, false, APIConstant.ResponseMessage.Error, APIConstant.ErrorMessage.DATANOTFOUND, APIConstant.ResponseStatusCode.NotFound);
            }


        }
        
        private async Task<FilmModel> GetFilm(int Id)
        {

            string requestEndpoint = APIConstant.Url.Film + Id;
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(requestEndpoint);

            if (httpResponse.IsSuccessStatusCode)
            {
                var Film = await httpResponse.Content.ReadAsStringAsync();
                FilmModel result = JsonConvert.DeserializeObject<FilmModel>(Film);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
