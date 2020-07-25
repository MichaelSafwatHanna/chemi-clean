using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ChemiClean.StorageService
{
    public class StorageApi
    {
        private const string StorageBasePath = "http://localhost:8080/";
        private const string ProductsEndpoint = "products/";
        public const string ProductsRoute = StorageBasePath + ProductsEndpoint;
        public static async Task<byte[]> GetNewProductDocument(string documentUrl)
        {
            byte[] body;
            using (var client = new HttpClient())
            {
                try
                {
                     body = await client.GetByteArrayAsync(documentUrl);
                }
                catch (Exception)
                {
                    throw new Exception("Url Broken");
                }
            }

            return body;
        }

        public static async Task<string> PostProductDocument(string name, byte[] documentBytes)
        {
            var route = StorageBasePath + ProductsEndpoint + name;
            var content = new ByteArrayContent(documentBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(route),
                    Method = HttpMethod.Post,
                    Content = content
                };
                await client.SendAsync(request);
            }

            return route;
        }

        public static async Task<byte[]> GetLocalProductDocument(string name)
        {
            var route = StorageBasePath + ProductsEndpoint + name;

            byte[] body;
            using (var client = new HttpClient())
            { 
                body = await client.GetByteArrayAsync(route);
            }

            return body;
        }

    }
}
