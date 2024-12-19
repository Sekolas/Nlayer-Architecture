using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services
{
   
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public List<string>? ErrorMassage { get; set; }

        [JsonIgnore]
        public bool IsSuccess => ErrorMassage == null || ErrorMassage.Count() == 0;

        [JsonIgnore]

        public bool IsFail => !IsSuccess;
        [JsonIgnore]

        public HttpStatusCode status { get; set; }
        [JsonIgnore]

        public string? url{ get; set; }


        public static ServiceResult<T> Succses(T? data,HttpStatusCode Status=HttpStatusCode.OK) {
            return new ServiceResult<T>()
            {
                Data = data,
                status = Status
            };

        }
        public static ServiceResult<T> SuccsesAsCreated(T? data,string url)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                status = HttpStatusCode.Created,
                url = url
            };

        }

        public static ServiceResult<T> Fail(List<string> errormassage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMassage = errormassage,
                status = Status
            };

        }

        public static ServiceResult<T> Fail(string errormassage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMassage = [errormassage],
                status = Status
            };

        }





    }
    public class ServiceResult
    {
        
        public List<string>? ErrorMassage { get; set; }
        public bool IsSuccess => ErrorMassage == null || ErrorMassage.Count() == 0;

        public bool IsFail => !IsSuccess;

        public HttpStatusCode status { get; set; }


        public static ServiceResult Succses(HttpStatusCode Status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                
                status = Status
            };

        }

        public static ServiceResult Fail(List<string> errormassage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMassage = errormassage,
                status = Status
            };

        }

        public static ServiceResult Fail(string errormassage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMassage = [errormassage],
                status = Status
            };

        }





    }

}
