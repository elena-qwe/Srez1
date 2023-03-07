using System;
using System.Collections.Generic;

namespace Srez1.Models;

public partial class User
{

    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? IdRole { get; set; }

    public int? IdInfoUser { get; set; }
}
