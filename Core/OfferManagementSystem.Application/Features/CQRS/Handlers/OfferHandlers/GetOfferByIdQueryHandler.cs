using OfferManagementSystem.Application.Features.CQRS.Queries.OfferQueries;
using OfferManagementSystem.Application.Features.CQRS.Queries.ProductQueries;
using OfferManagementSystem.Application.Features.CQRS.Results.OfferResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
{
	public class GetOfferByIdQueryHandler
	{

		private readonly IRepository<OfferMaster> _repository;

		public GetOfferByIdQueryHandler(IRepository<OfferMaster> repository)
		{
			_repository = repository;
		}




		public async Task<GetOfferByIdQueryResult> Handle(GetOfferByIdQuery query)
		{
			{
				var values = await _repository.GetByIdAsync(query.Id);
				return new GetOfferByIdQueryResult
				{
				ModifiedTime=values.ModifiedTime,
				UserId=values.UserId,
				//User=values.User,
				//StatusTransitions=values.StatusTransitions,
				StatusId=values.StatusId,
				//OfferDetails=values.OfferDetails,
				//Status = values.Status,
				Id=values.Id,
				CreatedAt=values.CreatedAt,
				CreatedTime = values.CreatedTime,
				CreatedUserId=values.CreatedUserId,
				//Customer = values.Customer,
				CustomerId=values.CustomerId,
				ValidityDate = values.ValidityDate
				
				

				
				};
			}
		}
	}
}
