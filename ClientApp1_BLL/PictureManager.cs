using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class PictureManager : BLLManager, IPictureManager
	{
		public PictureManager(IConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient) { }
		
		public async Task<ActionResult<List<Picture>>> GetPicturesFromRoom(int idRoom)
		{
			List<Picture> results = null;
            return results;
        }

    }
}
