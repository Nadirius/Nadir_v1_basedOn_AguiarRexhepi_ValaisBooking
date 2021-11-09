using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAPIL;

namespace BLL
{
    public class PictureManager : IPictureManager
    {
        private readonly IBookingWebApiInvoker _helloWorld;

        public PictureManager(IBookingWebApiInvoker apiInvoker)
        {
            this._helloWorld = apiInvoker;
        }
        public async Task<ActionResult<List<Picture>>> GetPicturesFromRoom(int idRoom)
        {
            List<Picture> results = null;
            return results;
        }

    }
}
