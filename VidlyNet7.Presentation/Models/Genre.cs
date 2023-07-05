using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Models
{
	public class Genre
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; } = string.Empty;
	}
}
