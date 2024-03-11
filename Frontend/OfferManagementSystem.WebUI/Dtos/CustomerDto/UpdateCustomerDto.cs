using OfferManagementSystem.Persistence;

namespace OfferManagementSystem.WebUI.Dtos.CustomerDto
{
	public class UpdateCustomerDto
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Phone { get; set; } = null!;

		public string Address { get; set; } = null!;

		public DateTime? CreatedTime { get; set; }

		public DateTime? ModifiedTime { get; set; }

		public int? UserId { get; set; }

		public virtual ICollection<OfferMaster> OfferMasters { get; set; } = new List<OfferMaster>();
	}
}
