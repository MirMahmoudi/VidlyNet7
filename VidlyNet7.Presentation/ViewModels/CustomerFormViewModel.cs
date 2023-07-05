using VidlyNet7.Presentation.Models;

namespace VidlyNet7.Presentation.ViewModels
{
	public class CustomerFormViewModel
	{
		public IEnumerable<MembershipType>? MembershipTypes { get; set; }
		public Customer? Customer { get; set; }

		public string Title
		{
			get
			{
				if (Customer is not null && Customer.Id != 0)
					return "Edit Customer";
				return "New Customer";
			}
		}
	}
}
