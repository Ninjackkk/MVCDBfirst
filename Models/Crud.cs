using System;
using System.Collections.Generic;

namespace MVCDBFirst.Models;

public partial class Crud
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Salary { get; set; }
}
