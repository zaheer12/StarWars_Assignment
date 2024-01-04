using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Web.Common
{
    public class Constants
    {
        public struct ResponseMessage
        {
            public const string Success = "Success";
            public const string Error = "Error";
        }
        public struct Url
        {
            public const string GetPeopleById = "api/People/GetPeopleById/";
            public const string GetMultiplePeople = "api/People/GetMultiplePeople/";
            public const string GetFilmById = "api/Film/GetFilmById/";
        }
        public struct ErrorMessage
        {
            public const string DATANOTFOUND = "Data/Id not found in system. Please check..";
        }

        public struct ResponseStatusCode
        {
            public const int Success = 200;
            public const int TooManyRequests = 429;
            public const int NoContent = 204;
            public const int InternalServerError = 500;
            public const int NotFound = 404;
            public const int Unauthorized = 401;
        }
    }
}
