using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Student
{
    public string Mssv { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Major { get; set; } = null!;
}
