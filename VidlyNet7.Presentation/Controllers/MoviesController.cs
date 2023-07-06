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

		// GET: Movies/New
		public IActionResult New()
		{
			var movieForm = new MovieFormViewModel
			{
				Genres = _dbContext.Genres.ToList()
			};
			return View("MovieForm", movieForm);
		}

		// POST: Movies/Save
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Save(Movie movie)
		{
			if (ModelState.IsValid)
			{
				if (movie.Id == 0)
				{
					movie.DateAdded = DateTime.Now;
					_dbContext.Movies.Add(movie);
				}
				else
				{
					var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
					movieInDb.Name = movie.Name;
					movieInDb.GenreId = movie.GenreId;
					movieInDb.NumberInStock = movie.NumberInStock;
					movieInDb.ReleaseDate = movie.ReleaseDate;
				}
				_dbContext.SaveChanges();

				return RedirectToAction("Index", "Movies");
			}

			var movieForm = new MovieFormViewModel(movie)
			{
				Genres = _dbContext.Genres.ToList()
			};
			return View("MovieForm", movieForm);
		}

		// GET: Movies/Edit/:id
		public IActionResult Edit(int id)
		{
			var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null) return NotFound();

			var movieForm = new MovieFormViewModel(movie)
			{
				Genres = _dbContext.Genres.ToList()
			};
			return View("MovieForm", movieForm);
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
