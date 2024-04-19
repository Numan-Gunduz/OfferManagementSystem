using OfferManagementSystem.Application.Features.CQRS.Queries.CustomerQueries;
using OfferManagementSystem.Application.Features.CQRS.Queries.ProductQueries;
using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Features.CQRS.Results.UserRoles;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers
{
	public class GetProductByIdQueryHandler
	{
		private readonly IRepository<Product> _repository;
		private readonly IRepository<UserMaster> _userRepository;

		public GetProductByIdQueryHandler(IRepository<Product> repository, IRepository<UserMaster> userRepository)
		{
			_repository = repository;
			_userRepository = userRepository;
		}




		public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
		{
			var customer = await _repository.GetByIdAsync(query.Id);

			if (customer == null)
			{
				// Handle the case where the customer with the specified id is not found
				return null;
			}

			// Müşterinin userId'sini kullanarak ilgili kullanıcıyı buluyoruz
			var user = await _userRepository.GetByIdAsync(customer.UserId ?? 0);

			if (user == null)
			{
				// Handle the case where the user with the specified id is not found
				return null;
			}

			// GetCustomerByIdQueryResult nesnesine kullanıcı adını ekliyoruz
			return new GetProductByIdQueryResult
			{
			//UserId = user.Id,
			Id = customer.Id,
			Name=customer.Name,
			CreatedTime=customer.CreatedTime,
			Description=customer.Description,
			ModifiedTime=customer.ModifiedTime,
			Price=customer.Price,
			

			
				UserName = user.FirstName,
				//User = new UserMaster { FirstName = user.FirstName } // Kullanıcı adını ekliyoruz
			};
		}
	}
}
