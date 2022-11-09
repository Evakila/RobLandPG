using System;
using System.Collections.Generic;

namespace RobLandPG.Models
{
    public partial class Tblclientdocument
    {
        public int Id { get; set; }
        public int? Clientid { get; set; }
        public string? Docname { get; set; }
        public string? Description { get; set; }
        public string? Contenttype { get; set; }
        public string? Username { get; set; }
        public byte[]? Document { get; set; }
    }
}
