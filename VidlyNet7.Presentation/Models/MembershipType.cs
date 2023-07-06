using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Models
{
	public class MembershipType
	{
		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;

		public int Id { get; set; }

		[Required] public string Name { get; set; } = string.Empty;

		public short SignUpFee { get; set; }

		public byte DurationInMonth { get; set; }

		public byte DiscountRate { get; set; }
	}
}