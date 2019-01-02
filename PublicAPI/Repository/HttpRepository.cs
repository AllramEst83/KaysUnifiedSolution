using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using PublicAPI.Interface;
using Newtonsoft.Json;
using System;
using System.Threading;
using PublicAPI.ApiModels;
using Microsoft.Extensions.Configuration;
using PublicAPI.ExceptionModels;
using System.Text;
using System.Net.Http.Headers;

namespace PublicAPI.Repository
{

    //REF: https://johnthiriet.com/efficient-api-calls/
    //REF-GIT-Source: https://github.com/johnthiriet/EfficientHttpClient

    public class HttpRepository : IHttpRepository
    {
        public IConfiguration _configuratio { get; }

        public HttpRepository(IConfiguration Configuration)
        {
            _configuratio = Configuration;
        }
        //GetAllUnicorns
        public async Task<List<UnicornApiModel>> GetAllUnicorns(CancellationToken cancellationToken)
        {
            string getUnicornsUrl = _configuratio.GetSection("ApiURl")["GetAllUnicornsUrl"];

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, getUnicornsUrl))
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                    return DeserializeJsonFromStream<List<UnicornApiModel>>(stream);

                var content = await StreamToStringAsync(stream);
                throw new CustomApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
        }

        //GetUnicornById
        public async Task<UnicornApiModel> GetUnicornById(Guid id)
        {
            string getUnicornByIdUrl = _configuratio.GetSection("ApiURl")["GetUnicornById"];

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, String.Format("{0}/{1}", getUnicornByIdUrl, id)))
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                    return DeserializeJsonFromStream<UnicornApiModel>(stream);

                var content = await StreamToStringAsync(stream);

                throw new CustomApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
        }

        //GenericHttpRequest
        public async Task<T> GenericHttpGet<T>(HttpParameters httpParameters)
        {
            string url = httpParameters.Id == Guid.Empty ? httpParameters.RequestUrl : String.Format("{0}/{1}", httpParameters.RequestUrl, httpParameters.Id);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, httpParameters.cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                    return DeserializeJsonFromStream<T>(stream);

                var content = await StreamToStringAsync(stream);
                throw new CustomApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
        }

        //DeserializeJsonFromStream
        private T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var jr = new JsonSerializer();
                var searchResult = jr.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        //StreamToStringAsync
        private async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
            {
                using (var sr = new StreamReader(stream))
                {
                    content = await sr.ReadToEndAsync();
                }
            }

            return content;
        }

        //SerializeJsonIntoStream
        public void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }

        //CreateHttpContent
        private HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }


        //PostStreamAsync
        public async Task<UnicornApiModel> PostStreamAsync(object content, CancellationToken cancellationToken)
        {
            string Url = _configuratio.GetSection("ApiURl")["AddUnicorn"];

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(true))
                {
                    response.EnsureSuccessStatusCode();

                    Stream streamResponse = await response.Content.ReadAsStreamAsync();

                   return DeserializeJsonFromStream<UnicornApiModel>(streamResponse);
                }
            }
        }

        //PutStreamAsync
        public async Task<UnicornApiModel> PutStreamAsync(object content, CancellationToken cancellationToken)
        {
            string Url = _configuratio.GetSection("ApiURl")["UpdateUnicorn"];

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Put, Url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(true))
                {
                    response.EnsureSuccessStatusCode();

                    Stream streamResponse = await response.Content.ReadAsStreamAsync();

                    return DeserializeJsonFromStream<UnicornApiModel>(streamResponse);
                }
            }
        }
    }
}
