using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Presentation.Data;
using VidlyNet7.Presentation.Dto;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.Controllers.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public MoviesController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_mapper = MapperConfig.InitializeAutoMapper();
		}

		// GET: /api/Movies
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDto>))]
		public IActionResult GetMovies()
		{
			var movies = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>( _dbContext.Movies.ToList() );
			return Ok(movies);
		}

		// GET: /api/Movies/:id
		[HttpGet]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetMovie(int id)
		{
			var movieInDb = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
			if (movieInDb == null) return NotFound();

			return Ok( _mapper.Map<Movie, MovieDto>(movieInDb) );
		}

		// POST: /api/Movies
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MovieDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult CreateMovie(MovieDto movieDto)
		{
			if(!ModelState.IsValid || movieDto.GenreId <= 0 || movieDto.GenreId > 21 ) return BadRequest();

			var movie = _mapper.Map<MovieDto, Movie>(movieDto);
			movie.DateAdded = DateTime.UtcNow;

			_dbContext.Movies.Add(movie);
			_dbContext.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri($"{Request.GetDisplayUrl()}/{movieDto.Id}"), movieDto);
		}

		// PUT: /api/Movies/:id
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid) return BadRequest();

			var movieInDb = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
			if (movieInDb == null) return NotFound();

			_mapper.Map(movieDto, movieInDb);
			_dbContext.SaveChanges();

			return Ok( _mapper.Map<Movie, MovieDto>(movieInDb) );
		}

		// DELETE: /api/Movies/:id
		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteMovie(int id)
		{
			var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
			if (movieInDb is null) return NotFound();

			_dbContext.Movies.Remove(movieInDb);
			_dbContext.SaveChanges();

			return Ok( _mapper.Map<Movie, MovieDto>(movieInDb) );
		}
	}
}
