using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WAPIL
{
    public class BookingWebApiInvoker : IBookingWebApiInvoker
    {
        public HttpClient _PleaseWAPI { get; set; }
        //private readonly HttpClient _PleaseWAPI;
        public BookingWebApiInvoker(HttpClient httpClient)
        {
            this._PleaseWAPI = httpClient;
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            return await _PleaseWAPI.GetFromJsonAsync<T>(uri);
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            var response = await _PleaseWAPI.PostAsJsonAsync(uri, obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            var response = await _PleaseWAPI.PutAsJsonAsync(uri, obj);
            await HandleError(response);
        }

        public async Task InvokeDelete(string uri)
        {
            var response = await _PleaseWAPI.DeleteAsync(uri);
            await HandleError(response);
        }

        private async Task HandleError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }
        }

    }
}
