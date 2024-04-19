
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
			private readonly IRepository<UserMaster> _userMasterRepository;
			private readonly IRepository<UserMaster> _offerDetailMaster;

		public GetOfferQueryHandler(IRepository<OfferMaster> repository, IRepository<CustomerMaster> customerMasterRepository, IRepository<OfferStatus> offerStatusRepository, IRepository<UserMaster> userMasterRepository, IRepository<UserMaster> offerDetailMaster)
		{
			_repository = repository;
			_customerMasterRepository = customerMasterRepository;
			_offerStatusRepository = offerStatusRepository;
			_userMasterRepository = userMasterRepository;
			_offerDetailMaster = offerDetailMaster;
		}

		public async Task<List<GetOfferQueryResult>> Handle()
		{
			var offers = await _repository.GetAllAsync();
			//var offerdetails = await _offerDetailMaster.GetAllAsync();
			//var offerDetailList =  offerdetails.ToList();
			var offerList = offers.ToList(); // Await edilmiş görevin sonucu alınıyor

				var results = new List<GetOfferQueryResult>();
			foreach (var offer in offerList)
			{
				var customerMaster = await _customerMasterRepository.GetByIdAsync(offer.CustomerId ?? 0);
				var status = await _offerStatusRepository.GetByIdAsync(offer.StatusId ?? 0);
				var userMaster = await _userMasterRepository.GetByIdAsync(offer.UserId ?? 0);
				//var offerdetail = await _offerDetailMaster.GetByIdAsync();
				if (customerMaster != null && status != null && userMaster != null)
				{

					results.Add(new GetOfferQueryResult
					{
						Id = offer.Id,
						//CustomerId = customerMaster.Id,
						//UserId = userMaster.Id,
						CreatedAt = offer.CreatedAt,
						ValidityDate = offer.ValidityDate,
						CreatedTime = offer.CreatedTime,
						ModifiedTime = offer.ModifiedTime,
					//	CreatedUserId = offer.CreatedUserId,
						OfferDetails = offer.OfferDetails,
						StatusName = status.StatusName,
						CustomerName = customerMaster.FirstName,
						UserName = userMaster.FirstName,
					//	StatusId= status.Id,
					//	createdUserName=userMaster.FirstName,
						





					});
				}
			}
				return results;
			}
		}
	}


