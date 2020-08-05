using System;
using System.Collections.Generic;
using System.Text;

namespace dtc.models
{
    public enum GuestStatus
    {
        Contacted,
        Scheduled,
        Confirmed
    }
    public class Guest : Person
    {
        public string EpisodeId { get; set; }
        public GuestStatus Status { get; set; }
    }
}
