using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLL
{

    public class HotelManager : BLLManager, IHotelManager
    {

		public HotelManager(IConfiguration configuration, HttpClient httpClient):base(configuration, httpClient){}


        public  async Task<ActionResult<Hotel>> GetHotelWithId(int idHotel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<List<string>>> GetLocationsAvailable()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<List<int>>> GetCategoriesAvailable()
        {
            throw new System.NotImplementedException();
        }
    }
}
