using OfferManagementSystem.Application.Features.CQRS.Queries.CustomerQueries;
using OfferManagementSystem.Application.Features.CQRS.Queries.ProductQueries;
using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers
{
	public class GetCustomerByIdQueryHandler
	{


		private readonly IRepository<CustomerMaster> _repository;

		public GetCustomerByIdQueryHandler(IRepository<CustomerMaster> repository)
		{
			_repository = repository;
		}




		public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
		{
			{
				var values = await _repository.GetByIdAsync(query.Id);
				return new GetCustomerByIdQueryResult
				{
				Phone=values.Phone,
				UserId=values.UserId,
				Address=values.Address,
				CreatedTime	= values.CreatedTime,
				Email=values.Email,
				FirstName=values.FirstName,
				LastName=values.LastName,
				Id=values.Id,
				ModifiedTime = values.ModifiedTime
				

				};
			}
		}



	}
}
