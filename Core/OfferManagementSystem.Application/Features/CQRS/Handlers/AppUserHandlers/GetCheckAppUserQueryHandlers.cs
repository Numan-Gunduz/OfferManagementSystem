//using OfferManagementSystem.Application.Features.CQRS.Results.AppUserResult;
//using OfferManagementSystem.Application.Features.CQRS.Results.CustomerResults;
//using OfferManagementSystem.Application.Interfaces;
//using OfferManagementSystem.Persistence.Context;
//using OfferManagementSystem.Persistence.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Text;
//using System.Threading.Tasks;

//namespace OfferManagementSystem.Application.Features.CQRS.Handlers.AppUserHandlers
//{
//	public class GetCheckAppUserQueryHandlers
//	{
//		private readonly IRepository<UsersRole> _usersRoleRepository;
//		private readonly IRepository<Role> _roleRepository;

//		public GetCheckAppUserQueryHandlers(IRepository<Role> roleRepository, IRepository<UsersRole> usersRoleRepository)
//		{
//			_roleRepository = roleRepository;
//			_usersRoleRepository = usersRoleRepository;
//		}
//		public async Task<List<GetCheckAppUserQueryResult>> Handle( int  query)
//		{
//			//var values = new GetCheckAppUserQueryResult();

//			var customers = await _usersRoleRepository.GetAllAsync();
//			var results = new List<GetCheckAppUserQueryResult>();

//			foreach (var customer in customers)
//			{
//				var user = await _usersRoleRepository.GetByIdAsync(customer.UserId ?? 0);

//				results.Add(new GetCheckAppUserQueryResult
//				{
//					Id= customer.Id,
//					UserName=customer.User.FirstName,
//					Role=customer.Role.RoleName,
				

//				});

//				return results;
//			}
//		}
//	}

//}