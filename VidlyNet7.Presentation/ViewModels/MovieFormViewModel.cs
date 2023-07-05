using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre>? Genres { get; set; }
		public Movie? Movie { get; set; }

		public string Title
		{
			get
			{
				if (Movie is not null && Movie.Id != 0)
					return "Edit Movie";
				return "New Movie";
			}
		}
	}
}
