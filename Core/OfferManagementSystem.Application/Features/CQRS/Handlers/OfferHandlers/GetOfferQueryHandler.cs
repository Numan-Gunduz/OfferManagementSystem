//using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
//using OfferManagementSystem.Application.Features.CQRS.Results.OfferResults;
//using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
//using OfferManagementSystem.Application.Interfaces;
//using OfferManagementSystem.Persistence;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
//{
//	public class GetOfferQueryHandler
//	{

//		private readonly IRepository<OfferMaster> _repository;
//		private readonly IRepository<CustomerMaster> _customerMasterRepository;

//		public GetOfferQueryHandler(IRepository<OfferMaster> repository, IRepository<CustomerMaster> customerMasterRepository)
//		{
//			_repository = repository;
//			_customerMasterRepository = customerMasterRepository;
//		}
//		public async Task<List<GetOfferQueryResult>> Handle()


//		{

//			var offer = await _repository.GetAllAsync();
//			var results = new List<GetOfferQueryResult>();
//			foreach (var x in offer)
//			{
//				var user = await _customerMasterRepository.GetByIdAsync(x.UserId ?? 0);
//				results.Add(new GetOfferQueryResult
//				{


//					Id = x.Id,
//					ValidityDate = x.ValidityDate,
//					CustomerId = x.CustomerId,
//					Customer = x.Customer,
//					CreatedUserId = x.CreatedUserId,
//					CreatedTime = x.CreatedTime,
//					CreatedAt = x.CreatedAt,
//					CustomerName = x.Customer?.FirstName,
//					UserName = x.User?.FirstName,
//					StatusName = x.Status?.StatusName,
//					createdUserName = x.User?.FirstName,

//					ModifiedTime = x.ModifiedTime,
//					OfferDetails = x.OfferDetails,
//					StatusId = x.StatusId,

//					UserId = x.UserId,
//				});

//			}



//			return results;
//		}
//	}
//}
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfferManagementSystem.Application.Features.CQRS.Results.OfferResults;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
{
	public class GetOfferQueryHandler
	{
		private readonly IRepository<OfferMaster> _repository;
		private readonly IRepository<CustomerMaster> _customerMasterRepository;
		private readonly IRepository<OfferStatus> _offerStatusRepository;

		public GetOfferQueryHandler(IRepository<OfferMaster> repository, IRepository<CustomerMaster> customerMasterRepository,IRepository<OfferStatus> offerStatusRepository)
		{
			_repository = repository;
			_customerMasterRepository = customerMasterRepository;
			_offerStatusRepository = offerStatusRepository;
		}

		public async Task<List<GetOfferQueryResult>> Handle()
		{
			var offers = await _repository.GetAllAsync();
			var offerList = offers.ToList(); // Await edilmiş görevin sonucu alınıyor

			var results = new List<GetOfferQueryResult>();

			foreach (var offer in offerList)
			{
				var user = await _customerMasterRepository.GetByIdAsync(offer.CustomerId ?? 0);
				var status = await _offerStatusRepository.GetByIdAsync(offer.StatusId ?? 0);

				results.Add(new GetOfferQueryResult
				{
					Id = offer.Id,
					ValidityDate = offer.ValidityDate,
					CustomerId = offer.CustomerId,
					CustomerName = offer.Customer?.FirstName,
					UserName = user?.FirstName,
					StatusName = offer.Status?.StatusName,
					createdUserName = offer.User?.FirstName,
					CreatedTime = offer.CreatedTime,
					CreatedAt = offer.CreatedAt,
					ModifiedTime = offer.ModifiedTime,
					OfferDetails = offer.OfferDetails,
					StatusId = offer.StatusId,
					UserId = offer.UserId
				});
			}

			return results;
		}
	}
}


