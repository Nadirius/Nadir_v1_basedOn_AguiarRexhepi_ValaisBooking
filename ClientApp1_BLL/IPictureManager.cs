using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	public interface IPictureManager
	{
		Task<ActionResult<List<Picture>>> GetPicturesFromRoom(int idRoom);
	}
}