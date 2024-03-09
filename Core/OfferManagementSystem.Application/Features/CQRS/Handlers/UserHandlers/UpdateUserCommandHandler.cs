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
	public class UpdateUserCommandHandler
	{
		private readonly IRepository<UserMaster> _repository;

		public UpdateUserCommandHandler(IRepository<UserMaster> repository)
		{
			_repository = repository;
		}
		
		public async Task Handle(UpdateUserCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);
			values.Email = command.Email;
			values.Password = command.Password;
			values.CreatedTime = command.CreatedTime;
			values.CreatedUserId = command.CreatedUserId;
			values.ModifiedTime = command.ModifiedTime;
			values.FirstName = command.FirstName;
			values.LastName = command.LastName;
			await _repository.UpdateAsync(values);
		}
	}
}
