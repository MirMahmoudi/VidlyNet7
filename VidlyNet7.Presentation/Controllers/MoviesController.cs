using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Presentation.Data;
using VidlyNet7.Presentation.Models;
using VidlyNet7.Presentation.ViewModels;

namespace VidlyNet7.Presentation.Controllers
{
	public class MoviesController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public MoviesController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: Movies
		public IActionResult Index()
		{
			var movies = _dbContext.Movies.Include(m => m.Genre);
			return View(movies);
		}

		// GET: Movies/Details/Id
		public IActionResult Details(int id)
		{
			var movie = _dbContext.Movies
				.Include(m => m.Genre)
				.SingleOrDefault(m => m.Id == id);

			if (movie is null) return NotFound();
			return View(movie);
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

	}
}
