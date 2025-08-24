using System;
using System.Collections.Generic;

namespace Buoi2_DataAccess.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fullname { get; set; } = null!;
}
