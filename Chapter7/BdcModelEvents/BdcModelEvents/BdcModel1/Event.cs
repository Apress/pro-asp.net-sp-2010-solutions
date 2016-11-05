using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BdcModelEvents.BdcModel1
{
    /// <summary>
    /// Event class
    /// </summary>
    public partial class Event
    {
        public Int32 EventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
    }
}
