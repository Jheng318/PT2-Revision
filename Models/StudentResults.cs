using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PT2Revision.Models
{
    public partial class StudentResults
    {
        public int ResultsId { get; set; }
        public int Marks { get; set; }
        public int ModuleId { get; set; }
        public int StudentId { get; set; }

        public virtual Modules Module { get; set; }
        public virtual Students Student { get; set; }
    }
}
