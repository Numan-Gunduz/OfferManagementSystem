using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers
{
	public class UpdateProductCommandHandler
	{
		private readonly IRepository<Product> _repository;

		public UpdateProductCommandHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateProductCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);
			values.Description = command.Description;
			values.Price = command.Price;
			values.CreatedTime = command.CreatedTime;
			values.UserId = command.UserId;
			values.ModifiedTime = command.ModifiedTime;
			values.Name = command.Name;
			values.Id = command.Id;

		}
	}
}
