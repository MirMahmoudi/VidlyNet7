using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Dto
{
	public class MembershipTypeDto
	{
		public int Id { get; set; }

		[Required] public string Name { get; set; } = string.Empty;

		public byte DiscountRate { get; set; }
	}
}
