using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Results.OfferResults
{
	public class GetOfferQueryResult
	{
			public int Id { get; set; }


			public DateTime? CreatedAt { get; set; }

			public DateTime ValidityDate { get; set; }


			public DateTime? CreatedTime { get; set; }

			public DateTime? ModifiedTime { get; set; }

			public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();
        public string? CustomerName { get; set; }
        public string? UserName { get; set; }
		public string? StatusName { get; set; }
		//public string? ProductName { get; set; }
		//public double? quantity { get; set; }
		//public double? unitpriece { get; set; }
		//public double? totalpriece { get; set; }

		//	public virtual OfferStatus? Status { get; set; }

		//	public virtual ICollection<StatusTransition> StatusTransitions { get; set; } = new List<StatusTransition>();

		//	public virtual UserMaster? User { get; set; }
		//	public int? CustomerId { get; set; }

		//public int? UserId { get; set; }
		// public string? createdUserName { get; set; }

		//	public int? CreatedUserId { get; set; }

		//public virtual CustomerMaster? Customer { get; set; }
		//public int? StatusId { get; set; }

	}
}
