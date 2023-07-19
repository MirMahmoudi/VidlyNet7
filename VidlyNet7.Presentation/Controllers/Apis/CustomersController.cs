using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Presentation.Data;
using VidlyNet7.Presentation.Dto;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.Controllers.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public CustomersController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_mapper = MapperConfig.InitializeAutoMapper();
		}


		// GET: /api/Customers
		[HttpGet]
		[ProducesResponseType( StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>) )]
		public IActionResult GetCustomers()
		{
			var customersInDb = _dbContext.Customers.Include(c => c.MembershipType);
			var customers = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customersInDb);
			return Ok( customers );
		}

		// GET: /api/Customers/:id
		[HttpGet]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetCustomer(int id)
		{
			var customerInDb = _dbContext.Customers
				.Include(c => c.MembershipType)
				.SingleOrDefault(x => x.Id == id);

			if (customerInDb is null) return NotFound();

			return Ok( _mapper.Map<Customer, CustomerDto>(customerInDb) );
		}

		// POST: /api/Customers
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid || customerDto.MembershipTypeId is <= 0 or > 4) return BadRequest();

			var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

			_dbContext.Customers.Add(customer);
			_dbContext.SaveChanges();

			customerDto.Id = customer.Id;
			return Created(new Uri($"{Request.GetDisplayUrl()}/{customerDto.Id}"), customerDto);
		}

		// PUT: /api/Customers/:id
		[HttpPut]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
		{
			if(!ModelState.IsValid || customerDto.MembershipTypeId <= 0) return BadRequest();

			var customerInDb = _dbContext.Customers.SingleOrDefault( x => x.Id == id);
			if(customerInDb is null) return NotFound();

			_mapper.Map(customerDto, customerInDb);
			_dbContext.SaveChanges();

			return Ok(_mapper.Map<Customer, CustomerDto>(customerInDb) );
		}

		// DELETE: /api/Customers/:id
		[HttpDelete]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteCustomer(int id)
		{
			var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

			if( customerInDb is null) return NotFound();

			_dbContext.Remove(customerInDb);
			_dbContext.SaveChanges();

			return Ok(_mapper.Map<Customer, CustomerDto>(customerInDb));
		}
	}
}
