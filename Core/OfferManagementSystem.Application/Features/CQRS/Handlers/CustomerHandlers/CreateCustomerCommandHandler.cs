using OfferManagementSystem.Application.Features.CQRS.Commands.CustomerCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers
{
	public class CreateCustomerCommandHandler
	{
		private readonly IRepository<CustomerMaster> _repository;

		public CreateCustomerCommandHandler(IRepository<CustomerMaster> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateCustomerCommand command)
		{
			await _repository.CreateAsync(new CustomerMaster
			{
			Email = command.Email,
			FirstName = command.FirstName,
			LastName = command.LastName,
			ModifiedTime = command.ModifiedTime,
			CreatedTime = command.CreatedTime,
			Address = command.Address,
			Phone = command.Phone,
			UserId = command.UserId,

			});
		}
	}
}
