using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Dto
{
	public class GenreDto
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; } = string.Empty;
	}
}
