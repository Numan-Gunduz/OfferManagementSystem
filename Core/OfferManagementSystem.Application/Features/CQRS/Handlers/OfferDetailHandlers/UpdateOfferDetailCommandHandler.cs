using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.OfferDetailCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferDetailHandlers
{
	public class UpdateOfferDetailCommandHandler
	{
		private readonly IRepository<OfferDetail> _repository;

		public UpdateOfferDetailCommandHandler(IRepository<OfferDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateOfferDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);
			values.Id = command.Id;

			values.OfferId = command.OfferId;
			values.ProductId = command.ProductId;
			values.UnitPrice = command.UnitPrice;
			values.Quantity = command.Quantity;
			values.ModifiedTime = command.ModifiedTime;
			values.CreatedTime = command.CreatedTime;
			values.TotalPrice = command.TotalPrice;
			values.UserId = command.UserId;


			await _repository.UpdateAsync(values);

		}
	}
}
