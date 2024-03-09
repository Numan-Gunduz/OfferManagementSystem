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
	public class RemoveProductCommandHandler
	{
		private readonly IRepository<Product> _repository;

		public RemoveProductCommandHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveProductCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
