

using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfferManagementSystem.Application.Features.CQRS.Queries.CustomerQueries;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers
{
	public class GetCustomerByIdQueryHandler
	{
		private readonly IRepository<CustomerMaster> _repository;
		private readonly IRepository<UserMaster> _userRepository;

		public GetCustomerByIdQueryHandler(IRepository<CustomerMaster> repository, IRepository<UserMaster> userRepository)
		{
			_repository = repository;
			_userRepository = userRepository;
		}

		public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
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
			return new GetCustomerByIdQueryResult
			{
				Id = customer.Id,
				CreatedTime = customer.CreatedTime,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Address = customer.Address,
				Email = customer.Email,
				ModifiedTime = customer.ModifiedTime,
				Phone = customer.Phone,
				UserId = customer.UserId,
				UserName = user.FirstName,
				//User = new UserMaster { FirstName = user.FirstName } // Kullanıcı adını ekliyoruz
			};
		}
	}
}

