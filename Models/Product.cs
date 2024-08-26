using System;
using System.Collections.Generic;

namespace MVCDBFirst.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Pname { get; set; }

    public string? Pcat { get; set; }

    public decimal? Price { get; set; }
}
