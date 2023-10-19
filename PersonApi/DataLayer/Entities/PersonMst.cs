using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class PersonMst
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
