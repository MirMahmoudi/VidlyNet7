using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Dto
{
	public class MovieDto
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int GenreId { get; set; }

		public GenreDto? Genre { get; set; }

		public DateTime? DateAdded { get; set; }

		public DateTime ReleaseDate { get; set; }

		[Range(1, 20)]
		public int NumberInStock { get; set; }
	}
}
