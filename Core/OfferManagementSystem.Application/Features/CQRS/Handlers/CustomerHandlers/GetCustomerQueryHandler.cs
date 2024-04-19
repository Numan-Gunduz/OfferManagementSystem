
using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers
{
	public class GetCustomerQueryHandler
	{
		private readonly IRepository<CustomerMaster> _repository;
		private readonly IRepository<UserMaster> _userRepository; // UserMaster tablosunu kullanabilmek için bir IRepository alanı ekledik

		public GetCustomerQueryHandler(IRepository<CustomerMaster> repository, IRepository<UserMaster> userRepository)
		{
			_repository = repository;
			_userRepository = userRepository;
		}

		public async Task<List<GetCustomerQueryResult>> Handle()


		{
			var customers = await _repository.GetAllAsync();
			var results = new List<GetCustomerQueryResult>();

			foreach (var customer in customers)
			{
				var user = await _userRepository.GetByIdAsync(customer.UserId ?? 0);

				results.Add(new GetCustomerQueryResult
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
					UserName = user != null ? user.FirstName : "Bilinmiyor" // Kullanıcı adını ekledik veya "Unknown" olarak ayarladık
				});
			}

			return results;
		}
	}
}

