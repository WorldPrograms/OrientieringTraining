using System;
using System.Collections.Generic;

namespace CodeBase.Data
{
    public class CompetitorOnEvent
    {
        public CompetitorOnEvent(Competitor competitor) =>
            Competitor = competitor;

        public Competitor Competitor;
        public DateTime EventResult { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public List<DateTime> ControlsTimes { get; set; }
    }
}
