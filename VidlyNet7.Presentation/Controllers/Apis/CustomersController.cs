using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Presentation.Data;
using VidlyNet7.Presentation.Dto;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.Controllers.NewFolder
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
			var customers = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(_dbContext.Customers.ToList());
			return Ok( customers );
		}

		// GET: /api/Customers/:id
		[HttpGet]
		[Route("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetCustomer(int id)
		{
			var customerInDb = _dbContext.Customers.SingleOrDefault(x => x.Id == id);
			if (customerInDb is null) return NotFound();

			return Ok( _mapper.Map<Customer, CustomerDto>(customerInDb) );
		}

		// POST: /api/Customers
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid || customerDto.MembershipTypeId <= 0 || customerDto.MembershipTypeId > 4) return BadRequest();

			var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

			_dbContext.Customers.Add(customer);
			_dbContext.SaveChanges();

			customerDto.Id = customer.Id;
			return Created(new Uri($"{Request.GetDisplayUrl()}/{customerDto.Id}"), customerDto);
		}

		// PUT: /api/Customers/:id
		[HttpPut]
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
