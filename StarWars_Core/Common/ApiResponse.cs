using StarWars_Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars_Core.Common
{
    public class ApiResponse<T>
    {
        public bool? Status { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse<T> SetResponse(T data, string message = APIConstant.ResponseMessage.Success,
            bool? status = true, int? statusCode = APIConstant.ResponseStatusCode.Success)
        {
            Status = status;
            StatusCode = statusCode;
            Message = message;
            Data = data;

            return this;
        }

    }
}
