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
    public class GetOfferDetailQueryHandler
	{
		private readonly IRepository<OfferDetail> _offerDetailrepository;
		private readonly IRepository<OfferMaster> _offerMasterrepository;
		private readonly IRepository<Product> _productRepository;
		private readonly IRepository<UserMaster> _userRepository;




		public GetOfferDetailQueryHandler(IRepository<OfferDetail> offerDetailrepository, IRepository<OfferMaster> offerMasterrepository, IRepository<Product> productRepository, IRepository<UserMaster> userRepository)
		{
			_offerDetailrepository = offerDetailrepository;
			_offerMasterrepository = offerMasterrepository;
			_productRepository = productRepository;
			_userRepository = userRepository;
		}
		public async Task<List<GetOfferDetailQueryResult>> Handle()
		{
			var offerDetail = await _offerDetailrepository.GetAllAsync();
			var offerMaster = await _offerMasterrepository.GetAllAsync();
			var productMaster = await _productRepository.GetAllAsync();
			var userMaster = await _userRepository.GetAllAsync();
		
			var offerDetailList = offerDetail.ToList(); // Await edilmiş görevin sonucu alınıyor

			var results = new List<GetOfferDetailQueryResult>();
			foreach (var detail in offerDetailList)
			{
				var ana = await _offerMasterrepository.GetByIdAsync(detail.OfferId ?? 0);
				var urun = await _productRepository.GetByIdAsync(detail.ProductId ?? 0);
				var kullanici = await _userRepository.GetByIdAsync(detail.UserId ?? 0);
		

			
	
				//var offerdetail = await _offerDetailMaster.GetByIdAsync();
				if (ana != null && urun != null && kullanici != null)
				{

					results.Add(new GetOfferDetailQueryResult
					{
						Id = detail.Id,
						Quantity= detail.Quantity,
						UnitPrice= detail.UnitPrice,
						TotalPrice= detail.TotalPrice,
						CreatedTime=detail.CreatedTime,
						ModifiedTime=detail.ModifiedTime,
						ProductName=urun.Name,
						UserName=kullanici.FirstName,
						OfferId=detail.OfferId,
						ProductId=detail.ProductId,
						UserId = detail.UserId
					}); ;
				}
			}
			return results;
		}
	}
}
