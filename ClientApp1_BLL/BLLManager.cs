using Microsoft.Extensions.Configuration;
using System.Net.Http;


namespace BLL
{
    public abstract class BLLManager
    {
        #region ReservationManager properties

        protected readonly HttpClient _PleaseWAPI;
        protected string _AtValaisAccomodation;
        #endregion

        public BLLManager(IConfiguration configuration, HttpClient httpClient)
        {
            _PleaseWAPI = httpClient;
            this._AtValaisAccomodation = httpClient.BaseAddress.AbsoluteUri;
        }



    }
}
