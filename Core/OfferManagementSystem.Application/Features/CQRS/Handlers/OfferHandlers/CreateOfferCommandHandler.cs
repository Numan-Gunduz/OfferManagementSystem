﻿//using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
//using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
//using OfferManagementSystem.Application.Interfaces;
//using OfferManagementSystem.Persistence;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
//{
//	public class CreateOfferCommandHandler
//	{
//		private readonly IRepository<OfferMaster> _repository;


//		public CreateOfferCommandHandler(IRepository<OfferMaster> repository)
//		{
//			_repository = repository;
//		}
//		public async Task Handle(CreateOfferCommand command)
//		{
//			await _repository.CreateAsync(new OfferMaster
//			{
//			CreatedAt = command.CreatedAt,
//			CreatedTime = command.CreatedTime,
//			CreatedUserId = command.CreatedUserId,
//			Customer = command.Customer,
//			UserId=command.UserId,
//			CustomerId=command.CustomerId,

//			ModifiedTime = command.ModifiedTime,
//			//Status= command.Status,
//			OfferDetails = command.OfferDetails,
//			StatusId=command.StatusId,
//			//StatusTransitions = command.StatusTransitions,
//			User = command.User,
//			ValidityDate=command.ValidityDate,



//			});
//		}
//	}
//}

using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
{
    public class CreateOfferCommandHandler
    {
        private readonly IRepository<OfferMaster> _repository;
        private readonly IRepository<CustomerMaster> _customerRepository;

        public CreateOfferCommandHandler(IRepository<OfferMaster> repository, IRepository<CustomerMaster> customerRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task Handle(CreateOfferCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId ?? 0);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            var newOffer = new OfferMaster
            {
                CreatedAt = command.CreatedAt,
                CreatedTime = command.CreatedTime,
                CreatedUserId = command.CreatedUserId,
               //Customer = customer.FirstName,
                UserId = command.UserId,
                CustomerId = command.CustomerId,
                ModifiedTime = command.ModifiedTime,
                OfferDetails = command.OfferDetails,
                StatusId = command.StatusId,
                User = command.User,
                ValidityDate = command.ValidityDate
            };

            await _repository.CreateAsync(newOffer);
        }
    }
}

