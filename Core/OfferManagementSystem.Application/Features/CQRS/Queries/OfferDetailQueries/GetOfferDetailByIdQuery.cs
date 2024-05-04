using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Queries.OfferDetailQueries
{
	public class GetOfferDetailByIdQuery
	{
		public int Id { get; set; }

		public GetOfferDetailByIdQuery(int id)
		{
			Id = id;
		}
	}
}
