using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WAPIL
{
    public class BookingWebApiInvoker : IBookingWebApiInvoker
    {
        private readonly HttpClient _PleaseWAPI;
        private string _AtAvailableAccomodations;
        public BookingWebApiInvoker(HttpClient httpClient)
        {
            this._PleaseWAPI = httpClient;
            this._AtAvailableAccomodations = _PleaseWAPI.BaseAddress.AbsoluteUri;
        }

        public BookingWebApiInvoker(string baseUrl, HttpClient httpClient)
        {
            this._PleaseWAPI = httpClient;
            this._AtAvailableAccomodations = baseUrl;
            _PleaseWAPI.DefaultRequestHeaders.Accept.Clear();
            _PleaseWAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            return await _PleaseWAPI.GetFromJsonAsync<T>($"{_AtAvailableAccomodations}{uri}");
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            var response = await _PleaseWAPI.PostAsJsonAsync($"{_AtAvailableAccomodations}{uri}", obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            var response = await _PleaseWAPI.PutAsJsonAsync(_AtAvailableAccomodations, obj);
            await HandleError(response);
        }

        public async Task InvokeDelete(string uri)
        {
            var response = await _PleaseWAPI.DeleteAsync(_AtAvailableAccomodations);
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
