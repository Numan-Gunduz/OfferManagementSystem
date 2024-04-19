using OfferManagementSystem.Application.Features.CQRS.Queries.OfferQueries;
using OfferManagementSystem.Application.Features.CQRS.Queries.ProductQueries;
using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
using OfferManagementSystem.Application.Features.CQRS.Results.OfferResults;
using OfferManagementSystem.Application.Features.CQRS.Results.ProductResults;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers
{
	public class GetOfferByIdQueryHandler
	{

		private readonly IRepository<OfferMaster> _repository;
		private readonly IRepository<CustomerMaster> _customerMasterRepository;
		private readonly IRepository<OfferStatus> _offerStatusRepository;
		private readonly IRepository<UserMaster> _userMasterRepository;


		public GetOfferByIdQueryHandler(IRepository<OfferMaster> repository, IRepository<UserMaster> userMasterRepository, IRepository<OfferStatus> offerStatusRepository, IRepository<CustomerMaster> customerMasterRepository)
		{
			_repository = repository;
			_userMasterRepository = userMasterRepository;
			_offerStatusRepository = offerStatusRepository;
			_customerMasterRepository = customerMasterRepository;
		}




		public async Task<GetOfferByIdQueryResult> Handle(GetOfferByIdQuery query)
		{
			var offer = await _repository.GetByIdAsync(query.Id);

			var customermaster = await _customerMasterRepository.GetByIdAsync(offer.CustomerId ?? 0);

			var offerstatus = await _offerStatusRepository.GetByIdAsync(offer.StatusId ?? 0);
			var usermaster = await _userMasterRepository.GetByIdAsync(offer.UserId ?? 0);


			return new GetOfferByIdQueryResult
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
				StatusName = offerstatus.StatusName,
				CustomerName = customermaster.FirstName,
				UserName = usermaster.FirstName,
				//	StatusId= status.Id,
				//	createdUserName=userMaster.FirstName,

			};

		}
	}
}




