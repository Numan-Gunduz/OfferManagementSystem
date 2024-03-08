using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence;

public partial class UserMaster
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    public virtual ICollection<OfferMaster> OfferMasters { get; set; } = new List<OfferMaster>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
