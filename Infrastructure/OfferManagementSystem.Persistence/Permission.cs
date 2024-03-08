using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence;

public partial class Permission
{
    public int Id { get; set; }

    public string PermissionName { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
