using AutoMapper;
using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.Dto
{
	public class MapperConfig
	{
		public static Mapper InitializeAutoMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				// Customer
				cfg.CreateMap<Customer, CustomerDto>();
				cfg.CreateMap<CustomerDto, Customer>()
					.ForMember(c => c.Id, opt => opt.Ignore());
				
				// Membership
				cfg.CreateMap<MembershipType, MembershipTypeDto>();

				// Movie
				cfg.CreateMap<Movie, MovieDto>();
				cfg.CreateMap<MovieDto, Movie>()
					.ForMember(c => c.Id, opt => opt.Ignore());

				// Genre
				cfg.CreateMap<Genre, GenreDto>();
			});

			return new Mapper(config);
		}
	}
}
