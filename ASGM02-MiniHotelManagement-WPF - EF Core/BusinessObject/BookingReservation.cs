using BusinessObject;
using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class BookingReservation
{
    public int BookingReservationId { get; set; }

    public DateOnly BookingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public decimal? TotalPrice { get; set; } = 0;

    public int CustomerId { get; set; }

    public byte? BookingStatus { get; set; } = 1;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer Customer { get; set; } = null!;
}
