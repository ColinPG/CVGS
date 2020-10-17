using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class EventLog
    {
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Event { get; set; }
        public string Detail { get; set; }
    }
}
