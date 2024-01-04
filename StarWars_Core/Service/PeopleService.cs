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

    public class PeopleService : IPeopleService
    {
        //private readonly IPeopleRepository _peopleRepository;
        private readonly HttpClient _httpClient;

        public PeopleService(HttpClient httpClient)
        {
            //_peopleRepository = peopleRepository;
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<string>> TestPing()
        {
            string? success = "Test Ping";
            var data = await Task.Run(() =>
              {
                  return ResponseHelper.GetResponse(success);
              });
            return data;
        }
        public async Task<ApiResponse<PeopleModel?>> GetPeopleById(int id)
        {
            var result = await GetPeople(id);
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
        public async Task<ApiResponse<List<PeopleModel>>> GetMultiplePeople()
        {

            Task[] tasks = new Task[4];
            tasks[0] = GetPeople(1);
            tasks[1] = GetPeople(2);
            tasks[2] = GetPeople(3);
            tasks[3] = GetPeople(4);
            await Task.WhenAll(tasks);
            List<PeopleModel> results = new List<PeopleModel>();
            foreach (var task in tasks)
            {
                var result = ((Task<PeopleModel>)task).Result;
                results.Add(result);
            }
            if (results != null)
            {
                return ResponseHelper.GetResponse(results);
            }
            else
            {
                return ResponseHelper.GetResponse(results, false, APIConstant.ResponseMessage.Error, APIConstant.ErrorMessage.DATANOTFOUND, APIConstant.ResponseStatusCode.NotFound);
            }
        }
        private async Task<PeopleModel> GetPeople(int Id)
        {

            string requestEndpoint = APIConstant.Url.People + Id;
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(requestEndpoint);

            if (httpResponse.IsSuccessStatusCode)
            {
                var people = await httpResponse.Content.ReadAsStringAsync();
                PeopleModel result = JsonConvert.DeserializeObject<PeopleModel>(people);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
