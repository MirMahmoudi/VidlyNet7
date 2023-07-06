using System.ComponentModel.DataAnnotations;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre>? Genres { get; set; }
		public int? Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; } = string.Empty;


		[Required, Display(Name = "Genre")]
		public int? GenreId { get; set; }

		[Required, Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required, Display(Name = "Number in stock")]
		[Range(1, 20, ErrorMessage = "Should be between 1 and 20!")]
		public int? NumberInStock { get; set; }

		public string Title => Id != 0 ? "Edit Movie" : "New Movie";

		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			GenreId = movie.GenreId;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
		}
	}
}
