using OfferManagementSystem.Application.Features.CQRS.Commands.CustomerCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler
	{



		private readonly IRepository<CustomerMaster> _repository;

		public UpdateCustomerCommandHandler(IRepository<CustomerMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateCustomerCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);

			values.Email = command.Email;
			values.FirstName = command.FirstName;
			values.LastName = command.LastName;
			values.Address = command.Address;
			values.Phone = command.Phone;
			values.CreatedTime = command.CreatedTime;
			values.Id = command.Id;
			values.UserId = command.UserId;
			values.ModifiedTime = command.ModifiedTime;
			
			await _repository.UpdateAsync(values);

		}
	}
}
