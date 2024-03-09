using OfferManagementSystem.Application.Features.CQRS.Commands.UserCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers
{
	public class CreateUserCommandHandler
	{
		private readonly IRepository <UserMaster> _repository;

		public CreateUserCommandHandler(IRepository<UserMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateUserCommand command)
		{
			await _repository.CreateAsync(new UserMaster
			{
				FirstName = command.FirstName,
				LastName = command.LastName,
				CreatedUserId = command.CreatedUserId,
				CreatedTime = command.CreatedTime,
				Email = command.Email,
				Password = command.Password,
				ModifiedTime = command.ModifiedTime,


			});
				
				
			
				
			
		}
	}
}
