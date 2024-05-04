using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
using OfferManagementSystem.Application.Features.CQRS.Commands.OfferDetailCommands;
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
    public class CreateOfferDetailCommandHandler
	{
		private readonly IRepository<OfferDetail> _offerDetailrepository;
		private readonly IRepository<OfferMaster> _offerMasterrepository;
		private readonly IRepository<Product> _productRepository;
		private readonly IRepository<UserMaster> _userRepository;




		public CreateOfferDetailCommandHandler(IRepository<OfferDetail> offerDetailrepository, IRepository<OfferMaster> offerMasterrepository, IRepository<Product> productRepository, IRepository<UserMaster> userRepository)
		{
			_offerDetailrepository = offerDetailrepository;
			_offerMasterrepository = offerMasterrepository;
			_productRepository = productRepository;
			_userRepository = userRepository;
		}
		public async Task Handle(CreateOfferDetailCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			var product = await _productRepository.GetByIdAsync(command.ProductId ?? 0);

			if (product == null)
			{
			    throw new Exception("Müşteri Bulunamadı");
			}
			var user = await _userRepository.GetByIdAsync(command.UserId ?? 0);
			if (user == null)
			{
				throw new Exception("Kullanıcı Bulunamadı");
			}
			var newOfferDetail = new OfferDetail
			{
				Quantity = command.Quantity,
				UnitPrice=command.UnitPrice,
				TotalPrice=command.TotalPrice,
				CreatedTime= command.CreatedTime,
				ModifiedTime=command.ModifiedTime,
				OfferId=command.OfferId,
				ProductId=command.ProductId,
				UserId=command.UserId,


				
			};

			await _offerDetailrepository.CreateAsync(newOfferDetail);
		}
	}
}

