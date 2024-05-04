using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.OfferDetailCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferDetailHandlers
{
    public class RemoveOfferDetailCommandHandler
	{
		private readonly IRepository<OfferDetail> _repository;

		public RemoveOfferDetailCommandHandler(IRepository<OfferDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveOfferDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
