namespace GFood_CaseStudy.Core.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHeaders(this HttpClient httpClient, IDictionary<string, string>? headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }
    }
}
