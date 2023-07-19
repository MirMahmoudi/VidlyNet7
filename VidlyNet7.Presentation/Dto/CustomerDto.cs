using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Dto
{
	public class CustomerDto
	{
		public int? Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; } = string.Empty;

		public bool IsSubscribedToNewsletter { get; set; }

		public int MembershipTypeId { get; set; }

		public MembershipTypeDto? MembershipType { get; set; }

		public DateTime? Birthdate { get; set; }
	}
}
