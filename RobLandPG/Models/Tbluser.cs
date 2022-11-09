using System;
using System.Collections.Generic;

namespace RobLandPG.Models
{
    public partial class Tbluser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
