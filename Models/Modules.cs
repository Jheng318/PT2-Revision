using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PT2Revision.Models
{
    public partial class Modules
    {
        public Modules()
        {
            StudentResults = new HashSet<StudentResults>();
        }

        public int ModuleId { get; set; }
        public string Description { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }

        public virtual ICollection<StudentResults> StudentResults { get; set; }
    }
}
