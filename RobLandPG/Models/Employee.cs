using System;
using System.Collections.Generic;

namespace RobLandPG.Models
{
    public partial class Employee
    {
        public int Employeeid { get; set; }
        public string? Employeename { get; set; }
        public string? Department { get; set; }
        public DateOnly? Dateofjoining { get; set; }
        public string? Photofilename { get; set; }
    }
}
