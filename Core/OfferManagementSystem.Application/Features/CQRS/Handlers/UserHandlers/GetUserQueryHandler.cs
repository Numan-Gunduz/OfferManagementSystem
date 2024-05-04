using OfferManagementSystem.Application.Features.CQRS.Results.UserRoles;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OfferManagementSystem.Persistence;



namespace OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers
{

    public class GetUserQueryHandler
	{
		private readonly IRepository<UserMaster> _repository;

		public GetUserQueryHandler(IRepository<UserMaster> repository)
		{
			_repository = repository;
		}
		public async Task <List<GetUserByIdQueryResult>> Handle()
		{
			var values =  await _repository.GetAllAsync();
			return values.Select(x => new GetUserByIdQueryResult{
				Id = x.Id,
				CreatedTime = x.CreatedTime,
				CreatedUserId = x.CreatedUserId,
				Email = x.Email,
				FirstName = x.FirstName,
				LastName = x.LastName,
				ModifiedTime	= x.ModifiedTime,
				Password= x.Password
			}).ToList();
		}
	}
}
