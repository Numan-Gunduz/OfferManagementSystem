using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
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

		public GetProductQueryHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetProductQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetProductQueryResult
			{
				Id = x.Id,
				Description = x.Description,
				ModifiedTime = x.ModifiedTime,
				CreatedTime = x.CreatedTime,
				Name = x.Name,
				Price = x.Price,
				UserId = x.UserId
			}).ToList();
		}
	}
}
