using StarWars_Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars_Core.Common
{
    public static class ResponseHelper
    {
        public static ApiResponse<T?> GetResponse<T>(T? data, bool status = true,
            string successMes = APIConstant.ResponseMessage.Success, string errorMes = APIConstant.ResponseMessage.Error,
            int? statusCode = APIConstant.ResponseStatusCode.NoContent)
        {
            ApiResponse<T?> response = new();
            return status ? response.SetResponse(data, successMes) :
                response.SetResponse(default, errorMes, status, statusCode);
        }


    }
}
