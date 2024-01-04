using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Web.Common
{
    public static class ResponseHelper
    {
        public static ApiResponse<T?> GetResponse<T>(T? data, bool status = true,
            string successMes = Constants.ResponseMessage.Success, string errorMes = Constants.ResponseMessage.Error,
            int? statusCode = Constants.ResponseStatusCode.NoContent)
        {
            ApiResponse<T?> response = new();
            return status ? response.SetResponse(data, successMes) :
                response.SetResponse(default, errorMes, status, statusCode);
        }
        public class ApiResponse<T>
        {
            public bool? Status { get; set; }
            public int? StatusCode { get; set; }
            public string? Message { get; set; }
            public T? Data { get; set; }

            public ApiResponse<T> SetResponse(T data, string message = Constants.ResponseMessage.Success,
                bool? status = true, int? statusCode = Constants.ResponseStatusCode.Success)
            {
                Status = status;
                StatusCode = statusCode;
                Message = message;
                Data = data;

                return this;
            }

        }


    }
}
