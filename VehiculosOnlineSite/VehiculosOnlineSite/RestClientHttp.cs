using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace VehiculosOnlineSite
{
    public class RestClientHttp
    {
        public async Task<RestClientResponse> GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                return new RestClientResponse
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = await response.Content.ReadAsStringAsync()
                };
            }
        }

        public async Task<RestClientResponse<T>> GetAsync<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                var restClientResponse = new RestClientResponse<T>
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = response.StatusCode != HttpStatusCode.OK ?
                        default(T) :
                        await response.Content.ReadAsAsync<T>()
                };

                return restClientResponse;
            }
        }

        public async Task<RestClientResponse> GetAsync(string url, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await httpClient.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                return new RestClientResponse
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = await response.Content.ReadAsStringAsync()
                };
            }
        }

        public async Task<RestClientResponse<T>> GetAsync<T>(string url, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await httpClient.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                var restClientResponse = new RestClientResponse<T>
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = response.StatusCode != HttpStatusCode.OK ?
                        default(T) :
                        await response.Content.ReadAsAsync<T>()
                };

                return restClientResponse;
            }
        }

        public async Task<RestClientResponse> PostAsync(string url, object objectToPost)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                var response = await httpClient.PostAsJsonAsync(url, objectToPost);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                return new RestClientResponse
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = await response.Content.ReadAsStringAsync()
                };
            }
        }

        public async Task<RestClientResponse<T>> PostAsync<T>(string url, object objectToPost)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                var response = await httpClient.PostAsJsonAsync(url, objectToPost);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                var restClientResponse = new RestClientResponse<T>
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = response.StatusCode != HttpStatusCode.OK ?
                        default(T) :
                        await response.Content.ReadAsAsync<T>()
                };

                return restClientResponse;
            }
        }

        public async Task<RestClientResponse> PostAsync(string url, object objectToPost, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                var response = await httpClient.PostAsJsonAsync(url, objectToPost);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                return new RestClientResponse
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = await response.Content.ReadAsStringAsync()
                };
            }
        }

        public async Task<RestClientResponse<T>> PostAsync<T>(string url, object objectToPost, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                var response = await httpClient.PostAsJsonAsync(url, objectToPost);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Token inválido");

                var restClientResponse = new RestClientResponse<T>
                {
                    StatusCode = (int)response.StatusCode,
                    StatusName = response.StatusCode,
                    Message = response.ReasonPhrase,
                    Response = response.StatusCode != HttpStatusCode.OK ?
                        default(T) :
                        await response.Content.ReadAsAsync<T>()
                };

                return restClientResponse;
            }
        }
    }
}
