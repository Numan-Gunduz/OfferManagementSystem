using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence;

public partial class RolePermission
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? PermissionId { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual UserMaster? CreatedUser { get; set; }

    public virtual Permission? Permission { get; set; }

    public virtual Role? Role { get; set; }
}
