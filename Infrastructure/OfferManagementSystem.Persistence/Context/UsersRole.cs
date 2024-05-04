using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence.Context;

public partial class UsersRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual UserMaster? User { get; set; }
}
