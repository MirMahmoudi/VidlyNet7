using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; }

		[Required]
		public Genre Genre { get; set; }

		public int GenreId { get; set; }

		public DateTime DateAdded { get; set; }

		public DateTime ReleaseDate { get; set; }

		public int NumberInStock { get; set; }
	}
}
