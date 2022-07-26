using Newtonsoft.Json;
using System.Net;

namespace GFood_CaseStudy.Core.Utilities.Results
{
    public class ErrorDetail
    {
        public string Message { get; set; } = "Error";
        public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
