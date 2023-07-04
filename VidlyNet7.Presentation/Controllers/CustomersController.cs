using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.Controllers
{
	public class CustomersController : Controller
	{
		// GET: Customers
		public IActionResult Index()
		{
			var customers = GetCustomers();
			return View(customers);
		}

		// GET: Customers/Details/Id
		public IActionResult Details(int id)
		{
			var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
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
