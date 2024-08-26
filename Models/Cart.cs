using System;
using System.Collections.Generic;

namespace MVCDBFirst.Models;

public partial class Cart
{
    public int Pid { get; set; }

    public string? Pname { get; set; }

    public string? Pcat { get; set; }

    public double Price { get; set; }

    public string? Picture { get; set; }

    public string? Suser { get; set; }
}
