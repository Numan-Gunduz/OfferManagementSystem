using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
{
	public class CreateOfferCommandHandler
	{
		private readonly IRepository<OfferMaster> _repository;

		public CreateOfferCommandHandler(IRepository<OfferMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateOfferCommand command)
		{
			await _repository.CreateAsync(new OfferMaster
			{
			CreatedAt = command.CreatedAt,
			CreatedTime = command.CreatedTime,
			CreatedUserId = command.CreatedUserId,
			//Customer = command.Customer,
			UserId=command.UserId,
			CustomerId=command.CustomerId,
			ModifiedTime = command.ModifiedTime,
			//Status= command.Status,
			//OfferDetails = command.OfferDetails,
			StatusId=command.StatusId,
			//StatusTransitions = command.StatusTransitions,
			//User = command.User,
			ValidityDate=command.ValidityDate,
		


			});
		}
	}
}
