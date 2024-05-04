using OfferManagementSystem.Application.Features.CQRS.Queries.OfferDetailQueries;
using OfferManagementSystem.Application.Features.CQRS.Queries.OfferQueries;
using OfferManagementSystem.Application.Features.CQRS.Results.OfferDetailResults;
using OfferManagementSystem.Application.Features.CQRS.Results.OfferResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using OfferManagementSystem.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferDetailHandlers
{
    public class GetOfferDetailByIdQueryHandler
	{


		private readonly IRepository<OfferDetail> _offerDetailrepository;
		private readonly IRepository<OfferMaster> _offerMasterrepository;
		private readonly IRepository<Product> _productRepository;
		private readonly IRepository<UserMaster> _userRepository;




		public GetOfferDetailByIdQueryHandler(IRepository<OfferDetail> offerDetailrepository, IRepository<OfferMaster> offerMasterrepository, IRepository<Product> productRepository, IRepository<UserMaster> userRepository)
		{
			_offerDetailrepository = offerDetailrepository;
			_offerMasterrepository = offerMasterrepository;
			_productRepository = productRepository;
			_userRepository = userRepository;
		}
		public async Task<GetOfferDetailByIdQueryResult> Handle(GetOfferDetailByIdQuery query)
		{
			var offerDetail = await _offerDetailrepository.GetByIdAsync(query.Id);
			var offerMaster = await _offerMasterrepository.GetByIdAsync(offerDetail.OfferId ?? 0);
			var productMaster = await _productRepository.GetByIdAsync(offerDetail.ProductId ?? 0);
			var UserMaster = await _userRepository.GetByIdAsync(offerDetail.UserId ?? 0);

			return new GetOfferDetailByIdQueryResult
			{
				Id = offerDetail.Id,
				OfferId = offerMaster.Id,
				UserId = UserMaster.Id,
				ProductId = productMaster.Id,
				CreatedTime = offerDetail.CreatedTime,
				TotalPrice = offerDetail.TotalPrice,
				UnitPrice = offerDetail.UnitPrice,
				ModifiedTime = offerDetail.ModifiedTime,
				Quantity = offerDetail.Quantity,
				UserName = UserMaster.FirstName,
				ProductName = productMaster.Name,
				Price = productMaster.Price,
				Description = productMaster.Description




			};
		}
	}
}