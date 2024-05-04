using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
	{
		private readonly IRepository<Product> _repository;
		private readonly IRepository<UserMaster> _userMasterRepository;

		public GetProductQueryHandler(IRepository<Product> repository, IRepository<UserMaster> userMasterRepository)
		{
			_repository = repository;
			_userMasterRepository = userMasterRepository;
		}
		public async Task<List<GetProductQueryResult>> Handle()


		{
			var products = await _repository.GetAllAsync();
			var results = new List<GetProductQueryResult>();

			foreach (var product in products)
			{
				var user = await _userMasterRepository.GetByIdAsync(product.UserId ?? 0);

				results.Add(new GetProductQueryResult
				{
					UserId = user.Id,
					CreatedTime = product.CreatedTime,
					Description = product.Description,
					Id = product.Id,
					ModifiedTime	= product.ModifiedTime,
					Name = product.Name,
					Price= product.Price,

					UserName = user != null ? user.FirstName : "Bilinmiyor" // Kullanıcı adını ekledik veya "Unknown" olarak ayarladık
					 
				});
			}

			return results;
		}
	}
}
