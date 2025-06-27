using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MultiSupplierMTPlugin.Helpers
{
    static class FluentHttpClientExtensions
    {
        public static HttpRequestBuilder Get(this HttpClient client, string url) => new HttpRequestBuilder(client, HttpMethod.Get, url);
        public static HttpRequestBuilder Post(this HttpClient client, string url) => new HttpRequestBuilder(client, HttpMethod.Post, url);
    }

    class HttpRequestBuilder
    {
        private readonly HttpClient _client;        
        private readonly UriBuilder _uriBuilder;
        private readonly HttpRequestMessage _request;
        private readonly List<KeyValuePair<string, string>> _queryParams;

        public HttpRequestBuilder(HttpClient client, HttpMethod method, string url)
        {
            _client = client;
            _uriBuilder = new UriBuilder(url);
            _request = new HttpRequestMessage(method, _uriBuilder.Uri);
            _queryParams = new List<KeyValuePair<string, string>>();

            var parsed = HttpUtility.ParseQueryString(_uriBuilder.Query ?? "");
            foreach (string key in parsed.Keys)
            {
                if (key != null)
                    _queryParams.Add(new KeyValuePair<string, string>(key, parsed[key]));
            }
        }


        public HttpRequestBuilder AddHeader(string key, string value)
        {
            _request.Headers.TryAddWithoutValidation(key, value);
            return this;
        }

        public HttpRequestBuilder AddHeaders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            foreach (var header in headers)
                AddHeader(header.Key, header.Value);
            return this;
        }

        public HttpRequestBuilder AddHeaderIf(bool condition, string key, string value)
        {
            return condition ? AddHeader(key, value) : this;
        }

        public HttpRequestBuilder AddHeadersIf(bool condition, IEnumerable<KeyValuePair<string, string>> headers)
        {
            return condition ? AddHeaders(headers) : this;
        }


        public HttpRequestBuilder AddQuery(string key, string value)
        {
            _queryParams.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public HttpRequestBuilder AddQueries(IEnumerable<KeyValuePair<string, string>> queries)
        {
            foreach (var query in queries)
                AddQuery(query.Key, query.Value);
            return this;
        }

        public HttpRequestBuilder AddQueryIf(bool condition, string key, string value)
        { 
            return condition ? AddQuery(key, value) : this;
        }

        public HttpRequestBuilder AddQueriesIf(bool condition, IEnumerable<KeyValuePair<string, string>> queries)
        { 
            return condition ? AddQueries(queries) : this;
        }


        public HttpRequestBuilder SetBearerToken(string token)
        {
            _request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return this;
        }

        public HttpRequestBuilder SetBearerTokenIf(bool condition, string token)
        {
            return condition ? SetBearerToken(token) : this;
        }


        public HttpRequestBuilder SetBodyForm(Dictionary<string, string> formFields)
        {
            return SetBodyForm(formFields?.Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value)));
        }

        public HttpRequestBuilder SetBodyForm(IEnumerable<KeyValuePair<string, string>> formFields)
        {
            _request.Content = new FormUrlEncodedContent(formFields ?? Enumerable.Empty<KeyValuePair<string, string>>());
            return this;
        }


        public HttpRequestBuilder SetBodyJson(object body)
        {
            var json = JsonConvert.SerializeObject(body);
            _request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return this;
        }

        public HttpRequestBuilder SetBodyJsonString(string jsonString)
        {
            _request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return this;
        }

        public HttpRequestBuilder SetBodyJsonByteArray(byte[] jsonByteArray)
        {
            var content = new ByteArrayContent(jsonByteArray);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _request.Content = content;
            return this;
        }


        public async Task<string> ReceiveString(CancellationToken cancellationToken = default)
        {
            return await SendAsync(cancellationToken);
        }

        public async Task<T> ReceiveJson<T>(CancellationToken cancellationToken = default)
        {            
            var content = await SendAsync(cancellationToken);            

            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                throw new Exception($"JSON deserialization failed: {ex.Message}. Content\r\n: {content}");
            }
        }


        private async Task<string> SendAsync(CancellationToken cancellationToken = default)
        {
            if (_queryParams.Count > 0)
            {
                var queryString = string.Join("&", _queryParams.Select(kv =>
                    $"{WebUtility.UrlEncode(kv.Key)}={WebUtility.UrlEncode(kv.Value)}"));
                _uriBuilder.Query = queryString;
            }
            _request.RequestUri = _uriBuilder.Uri;

            var response = await _client.SendAsync(_request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Http Request Exception {(int)response.StatusCode} {response.ReasonPhrase}.\r\n{content}");
            }

            return content;
        }
    }
}
