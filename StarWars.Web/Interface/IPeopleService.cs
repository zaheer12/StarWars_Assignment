using StarWars.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StarWars.Web.Common.ResponseHelper;

namespace StarWars.Web.Interface
{
    public interface IPeopleService
    {
        
        Task<ApiResponse<PeopleModel>> GetPeopleById(string id);
        Task<ApiResponse<List<PeopleModel>>> GetMultiplePeople();
    }
}
