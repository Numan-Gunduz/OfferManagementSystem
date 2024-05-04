using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
	{
		private readonly IRepository<Product> _repository;
		private readonly IRepository<UserMaster> _userRepository;

		public CreateProductCommandHandler(IRepository<Product> repository, IRepository<UserMaster> userRepository)
		{
			_repository = repository;
			_userRepository = userRepository;
		}
		public async Task Handle (CreateProductCommand command)
		{

			var selectedUser = await _userRepository.GetByIdAsync(command.UserId ?? 0);
			if (selectedUser == null)
			{
				// Seçilen kullanıcı bulunamadıysa hata fırlat
				throw new Exception("Seçilen Kullanıcı Bulunamadı.");
			}
			await _repository.CreateAsync(new Product
			{
				CreatedTime = command.CreatedTime,
				Description = command.Description,
				ModifiedTime = command.ModifiedTime,
				Name = command.Name,
				Price = command.Price,
				UserId = command.UserId
				
			});
		}
	}
}
