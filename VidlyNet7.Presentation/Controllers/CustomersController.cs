using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Presentation.Data;
using VidlyNet7.Presentation.Models;
using VidlyNet7.Presentation.ViewModels;

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

		// GET: Customers/New
		public IActionResult New()
		{
			var customerFormModel = new CustomerFormViewModel
			{
				MembershipTypes = _dbContext.MembershipTypes.ToList()
			};

			return View("CustomerForm", customerFormModel);
		}

		// POST: Customers/Save
		[HttpPost]
		public IActionResult Save(Customer customer)
		{
			if (customer.Id == 0)
				_dbContext.Customers.Add(customer);
			else
			{
				var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
			}

			_dbContext.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}

		// GET: Customers/Edit/:id
		public IActionResult Edit(int id)
		{
			var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null) return NotFound();

			var customerFormModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _dbContext.MembershipTypes.ToList()
			};

			return View("CustomerForm", customerFormModel);
		}
	}
}
