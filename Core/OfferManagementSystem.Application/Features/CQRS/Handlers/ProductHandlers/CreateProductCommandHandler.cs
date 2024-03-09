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
	public class CreateProductCommandHandler
	{
		private readonly IRepository<Product> _repository;

		public CreateProductCommandHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}
		public async Task Handle (CreateProductCommand command)
		{
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
