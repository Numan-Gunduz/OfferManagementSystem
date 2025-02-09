﻿using OfferManagementSystem.Application.Features.CQRS.Commands.CustomerCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
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
		private readonly IRepository<UserMaster> _userReposirtory;

		public CreateCustomerCommandHandler(IRepository<CustomerMaster> repository, IRepository<UserMaster> userReposirtory)
		{
			_repository = repository;
			_userReposirtory = userReposirtory;
		}
		public async Task Handle(CreateCustomerCommand command)
		{
		

           
            var selectedUser = await _userReposirtory.GetByIdAsync(command.UserId ?? 0);

			if (selectedUser == null)
			{
				// Seçilen kullanıcı bulunamadıysa hata fırlat
				throw new Exception("Selected user not found.");
			}

			await _repository.CreateAsync(new CustomerMaster
			{
				Email = command.Email,
				FirstName = command.FirstName,
				LastName = command.LastName,
				ModifiedTime = command.ModifiedTime,
				CreatedTime = command.CreatedTime,
				Address = command.Address,
				Phone = command.Phone,
				UserId=command.UserId,
				
				//UserName=command.FirstName,
				






			});
			
		}
	}
}
