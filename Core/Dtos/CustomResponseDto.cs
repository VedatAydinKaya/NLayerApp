using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CustomResponseDto<T>
    {
        private int yas;

        //public CustomResponseDto( int yas)
        //{
        //    _yas = yas;
        //}

        public T Data { get; set; }

        public List<string>? Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        //  now let's create  static methods that returns(responses)  to client that        
        //  endpoints which has been already requested from clients


        /*   STATIC FACTORY METHODS  */ 

        public static CustomResponseDto<T> Success(T data, int statusCode)  // when endpoints responds a requests successfully
                                                                            //       that will be returbed dtos as an static methods

        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, Errors = null };
        }

        public static CustomResponseDto<T> Success(int statusCode)   // updated case that doesnt need T Data
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = null };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors) // when request from clients failed case
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error) 
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors =new List<string> { error} };
        }
    }
}
