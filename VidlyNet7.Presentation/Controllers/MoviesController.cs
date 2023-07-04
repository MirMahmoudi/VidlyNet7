using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Presentation.Models;
using VidlyNet7.Presentation.ViewModels;

namespace VidlyNet7.Presentation.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies
		public IActionResult Index()
		{
			var movies = GetMovies();
			return View(movies);
		}

		// GET: Movies/Random
		public IActionResult Random()
		{
			var movie = new Movie { Name = "Shrek" };
			var customers = new List<Customer>
			{
				new Customer { Name = "Customer1"},
				new Customer { Name = "Customer2"}
			};
			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);
		}

		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie { Id = 1, Name = "Shrek" },
				new Movie { Id = 2, Name = "Wall-e" }
			};
		}
	}
}
