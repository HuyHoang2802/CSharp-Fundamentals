using System;
using System.Collections.Generic;

namespace Buoi2_DataAccess.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }
}
