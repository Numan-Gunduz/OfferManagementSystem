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
	public class UpdateOfferCommandHandler
	{


		private readonly IRepository<OfferMaster> _repository;

		public UpdateOfferCommandHandler(IRepository<OfferMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateOfferCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);

			//values.OfferDetails = command.OfferDetails;
			//values.Customer=command.Customer;
			//values.StatusTransitions = command.StatusTransitions;
			//values.Status = command.Status;
			values.CreatedAt = command.CreatedAt;
			values.CreatedTime = command.CreatedTime;
			//values.User=command.User;
			values.CustomerId=command.CustomerId;
			values.CreatedUserId=command.CreatedUserId;
			values.ModifiedTime=command.ModifiedTime;
			values.ValidityDate=command.ValidityDate;
			values.Id=command.Id;
			values.StatusId=command.StatusId;
			values.UserId=command.UserId;

			await _repository.UpdateAsync(values);

		}
	}
}
