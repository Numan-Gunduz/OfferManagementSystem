using OfferManagementSystem.Application.Features.CQRS.Commands.UserCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers
{
    public class RemoveUserCommandHandler
	{
		private readonly IRepository <UserMaster> _repository;

		public RemoveUserCommandHandler(IRepository<UserMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle (RemoveUserCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
