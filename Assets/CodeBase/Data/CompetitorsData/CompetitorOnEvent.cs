using System;
using System.Collections.Generic;

namespace CodeBase.Data
{
    public class CompetitorOnEvent: ICompetitor
    {
        public CompetitorOnEvent(Competitor competitor) =>
            Competitor = competitor;

        public Competitor Competitor;
        public Gender Gender { get => Competitor.Gender; set => Competitor.Gender = value; }
        public string FirstName { get => Competitor.FirstName; set => Competitor.FirstName = value; }
        public string LastName { get => Competitor.LastName; set => Competitor.LastName = value; }
        public string AgeGroup { get => Competitor.AgeGroup; set => Competitor.AgeGroup = value; }

        public DateTime EventResult { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public List<DateTime> ControlsTimes { get; set; }
        
    }
}
