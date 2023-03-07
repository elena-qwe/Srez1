using System;
using System.Collections.Generic;

namespace Srez1.Models;

public partial class InfoUser
{
    public int Id { get; set; }

    public string? AddressHome { get; set; }

    public decimal? PhoneNumber { get; set; }

    public DateOnly? BirthdayDate { get; set; }
}
