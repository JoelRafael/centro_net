using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace CentroNet.Helpers
{
    public class ErrorHelper
    {
        public static ResponseObject Response(int StatusCode, string Message)
        {
            return new ResponseObject()
            {

                StatusCode = StatusCode,
                Message = Message
            };
        }

        public static List<ModelErrors> GetModelStateErrors(ModelStateDictionary Model)
        {
            return Model.Select(x => new ModelErrors() { Key = x.Key, Messages = x.Value.Errors.Select(y => y.ErrorMessage).ToList() }).ToList();
        }
    }

    public class ResponseObject
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class ModelErrors
    {

        public string Key { get; set; }
        public List<string> Messages { get; set; }
    }
}