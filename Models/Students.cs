using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PT2Revision.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentResults = new HashSet<StudentResults>();
        }

        public int StudentId { get; set; }
        public string AdminNo { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentResults> StudentResults { get; set; }
    }
}
