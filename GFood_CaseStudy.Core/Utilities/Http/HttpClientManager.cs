using GFood_CaseStudy.Core.Extensions;
using Newtonsoft.Json;

namespace GFood_CaseStudy.Core.Utilities.Http
{
    public class HttpClientManager<T>
    {
        public static async Task<T> PostAsync(string uri, HttpContent content, IDictionary<string, string>? headers = null)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.AddHeaders(headers);
                var response = await httpClient.PostAsync(uri, content);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static async Task<T> GetAsync(string uri, IDictionary<string, string>? headers = null)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.AddHeaders(headers);
                var response = await httpClient.GetAsync(uri);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static async Task<T> DeleteAsync(string uri, IDictionary<string, string>? headers = null)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.AddHeaders(headers);
                var response = await httpClient.DeleteAsync(uri);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static async Task<T> PutAsync(string uri, HttpContent content, IDictionary<string, string>? headers = null)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.AddHeaders(headers);
                var response = await httpClient.PutAsync(uri, content);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
