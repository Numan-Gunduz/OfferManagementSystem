using OfferManagementSystem.Application.Features.CQRS.Results.OfferResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
{
	public class GetOfferQueryHandler
	{

		private readonly IRepository<OfferMaster> _repository;

		public GetOfferQueryHandler(IRepository<OfferMaster> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetOfferQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOfferQueryResult
			{
				Id=x.Id,
				ValidityDate=x.ValidityDate,
				CustomerId=x.CustomerId,
				//Customer = x.Customer,
				CreatedUserId=x.CreatedUserId,
				CreatedTime = x.CreatedTime,
				CreatedAt = x.CreatedAt,
				//Status = x.Status,
				ModifiedTime = x.ModifiedTime,
				//OfferDetails = x.OfferDetails,
				StatusId = x.StatusId,
				//StatusTransitions = x.StatusTransitions,
				UserId = x.UserId,
				 //User=x.User


				

			}).ToList();
		}
	}
}
