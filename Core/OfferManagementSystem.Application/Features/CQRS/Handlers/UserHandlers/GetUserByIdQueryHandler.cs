using OfferManagementSystem.Application.Features.CQRS.Queries.UserQueries;
using OfferManagementSystem.Application.Features.CQRS.Results.UserRoles;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers
{
	public class GetUserByIdQueryHandler
	{
		private readonly IRepository<UserMaster>_repository;

		public GetUserByIdQueryHandler(IRepository<UserMaster> repository)
		{
			_repository = repository;
		}
		public  async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery quey)
		{
			var values = await _repository.GetByIdAsync(quey.Id);
			return new GetUserByIdQueryResult
			{
				Id = values.Id,
				CreatedTime = values.CreatedTime,
				CreatedUserId = values.CreatedUserId,
				Email = values.Email,
				FirstName = values.FirstName,
				LastName = values.LastName,
				ModifiedTime = values.ModifiedTime,
				Password = values.Password,

			};
		}
	}
}
