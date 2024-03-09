using OfferManagementSystem.Application.Features.CQRS.Queries.ProductQueries;
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
	public class GetProductByIdQueryHandler
	{
		private readonly IRepository<Product> _repository;

		public GetProductByIdQueryHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}




		public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
		{
			{
				var values = await _repository.GetByIdAsync(query.Id);
				return new GetProductByIdQueryResult
				{
					CreatedTime = values.CreatedTime,
					Description = values.Description,
					Id = values.Id,
					ModifiedTime = values.ModifiedTime,
					Name = values.Name,
					Price = values.Price,
					UserId = values.UserId,
				};
			}
		}
	}
}
