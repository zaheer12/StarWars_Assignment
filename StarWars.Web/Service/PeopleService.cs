using Newtonsoft.Json;
using StarWars.Web.Common;
using StarWars.Web.Interface;
using StarWars.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static StarWars.Web.Common.ResponseHelper;

namespace StarWars.Web.Service
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;

        public PeopleService(HttpClient httpClient)
        {
            //_peopleRepository = peopleRepository;
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<PeopleModel>>> GetMultiplePeople()
        {
            string requestEndpoint = Constants.Url.GetMultiplePeople;
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(requestEndpoint);
            List<PeopleModel> PeopleModel = null;
            if (httpResponse.IsSuccessStatusCode)
            {
                var people = await httpResponse.Content.ReadAsStringAsync();
                var getResponse = ResponseHelper.GetResponse(people);
                if (getResponse.StatusCode == Constants.ResponseStatusCode.Success)
                {
                    return JsonConvert.DeserializeObject<ApiResponse<List<PeopleModel>>>(getResponse.Data);
                }
                return ResponseHelper.GetResponse(PeopleModel, false, Constants.ResponseMessage.Error, Constants.ErrorMessage.DATANOTFOUND, Constants.ResponseStatusCode.NotFound); ;
            }
            else if ((int)httpResponse.StatusCode == Constants.ResponseStatusCode.TooManyRequests)
            {
                return ResponseHelper.GetResponse(PeopleModel, false, Constants.ResponseMessage.Error, httpResponse.ReasonPhrase, (int)httpResponse.StatusCode);
            }
            else
            {
                return ResponseHelper.GetResponse(PeopleModel, false, Constants.ResponseMessage.Error, Constants.ErrorMessage.DATANOTFOUND, Constants.ResponseStatusCode.NotFound);
            }
        }

        public async Task<ApiResponse<PeopleModel>> GetPeopleById(string Id)
        {
            string requestEndpoint = Constants.Url.GetPeopleById + Id;
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(requestEndpoint);
            PeopleModel PeopleModel = null;
            if (httpResponse.IsSuccessStatusCode)
            {
                var people = await httpResponse.Content.ReadAsStringAsync();
                var getResponse = ResponseHelper.GetResponse(people);
                if (getResponse.StatusCode == Constants.ResponseStatusCode.Success)
                {
                    return JsonConvert.DeserializeObject<ApiResponse<PeopleModel>>(getResponse.Data);
                }
                return ResponseHelper.GetResponse(PeopleModel, false, Constants.ResponseMessage.Error, Constants.ErrorMessage.DATANOTFOUND, Constants.ResponseStatusCode.NotFound); ;
            }
            else if ((int)httpResponse.StatusCode == Constants.ResponseStatusCode.TooManyRequests)
            {
                return ResponseHelper.GetResponse(PeopleModel, false, Constants.ResponseMessage.Error, httpResponse.ReasonPhrase, (int)httpResponse.StatusCode);
            }
            else
            {
                return  ResponseHelper.GetResponse(PeopleModel, false, Constants.ResponseMessage.Error, Constants.ErrorMessage.DATANOTFOUND, Constants.ResponseStatusCode.NotFound);
            }
        }

    }
}
