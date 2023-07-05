using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Presentation.Data;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.Controllers
{
	public class CustomersController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public CustomersController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: Customers
		public IActionResult Index()
		{
			var customers = _dbContext.Customers
				.Include(c => c.MembershipType);
			return View(customers);
		}

		// GET: Customers/Details/Id
		public IActionResult Details(int id)
		{
			var customer = _dbContext.Customers
				.Include(c => c.MembershipType)
				.SingleOrDefault(c => c.Id == id);

			if (customer is null) return NotFound();
			return View(customer);
		}

		private IEnumerable<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				new Customer { Id = 1, Name = "John Smith" },
				new Customer { Id = 2, Name = "Mar Williams" }
			};
		}
	}
}
