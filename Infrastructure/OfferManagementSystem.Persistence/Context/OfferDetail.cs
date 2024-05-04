using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence.Context;

public partial class OfferDetail
{
    public int Id { get; set; }

    public int? OfferId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? UserId { get; set; }

    public virtual OfferMaster? Offer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual UserMaster? User { get; set; }
}
