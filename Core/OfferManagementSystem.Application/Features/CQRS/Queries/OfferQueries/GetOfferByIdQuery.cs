using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Queries.OfferQueries
{
	public class GetOfferByIdQuery
	{
		public GetOfferByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
