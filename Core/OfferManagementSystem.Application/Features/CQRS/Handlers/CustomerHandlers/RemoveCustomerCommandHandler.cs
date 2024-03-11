using OfferManagementSystem.Application.Features.CQRS.Commands.CustomerCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers
{
	public class RemoveCustomerCommandHandler
	{


		private readonly IRepository<CustomerMaster> _repository;

		public RemoveCustomerCommandHandler(IRepository<CustomerMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveCustomerCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
