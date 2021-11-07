using DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI
{
	public class ClientInformationModel
	{
		public List<Room> ReservedRoom { get; set; }

		[Required]
		[RegularExpression("^[\\p{L} \\.'\\-]+$")]
		public string Firstname { get; set; }

		[Required]
		[RegularExpression("^[\\p{L} \\.'\\-]+$")]
		public string LastName { get; set; }
	}
}
