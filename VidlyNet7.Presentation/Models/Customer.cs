using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Presentation.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; } = string.Empty;

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}
