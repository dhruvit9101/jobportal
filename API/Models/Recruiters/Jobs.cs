using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Recruiters
{
    public class Jobs
    {
        public Int64 Id { get; set; }
        public string Refno { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}