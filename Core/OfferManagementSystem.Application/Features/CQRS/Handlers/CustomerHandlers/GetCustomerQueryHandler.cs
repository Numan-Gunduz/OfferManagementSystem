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
	public class GetCustomerQueryHandler
	{
		private readonly IRepository<CustomerMaster> _repository;
		public GetCustomerQueryHandler(IRepository<CustomerMaster> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCustomerQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCustomerQueryResult
			{
				Id = x.Id,
				CreatedTime = x.CreatedTime,
				FirstName=x.FirstName,
				LastName=x.LastName,
				Address=x.Address,
				Email=x.Email,
				ModifiedTime = x.ModifiedTime,
				Phone=x.Phone,
				UserId=x.UserId,
				
				

			}).ToList();
		}
	}
}
