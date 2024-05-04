using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Results.OfferDetailResults
{
	public class GetOfferDetailByIdQueryResult
	{
		public int Id { get; set; }

		public int? OfferId { get; set; }

		public int? ProductId { get; set; }

		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal TotalPrice { get; set; }

		public DateTime? CreatedTime { get; set; }

		public DateTime? ModifiedTime { get; set; }

		public int? UserId { get; set; }

		//public virtual OfferMaster? Offer { get; set; }
        public string? UserName { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        //public virtual Product? Product { get; set; }

        //public virtual UserMaster? User { get; set; }
    }
}
