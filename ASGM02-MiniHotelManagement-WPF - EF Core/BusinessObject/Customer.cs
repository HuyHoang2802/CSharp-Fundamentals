using System;
using System.Collections.Generic;

namespace BusinessObject;

public class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerFullName { get; set; }

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; }

    public DateOnly? CustomerBirthday { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public byte? CustomerStatus { get; set; } = 1;

    public string? Password { get; set; }

    public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
}
