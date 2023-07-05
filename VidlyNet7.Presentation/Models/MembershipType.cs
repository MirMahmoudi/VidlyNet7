using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Models
{
	public class MembershipType
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public short SignUpFee { get; set; }
		public byte DurationInMonth { get; set; }
		public byte DiscountRate { get; set; }
	}
}
