using System.Collections.Generic;

namespace CodeBase.Data
{
    public class CompetitorsAgeGroupOnEvent
    {
        public CompetitorsAgeGroupOnEvent(string ageGroupType, string customGroupName = null)
        {
            Competitors = new List<CompetitorOnEvent>();
            AgeGroupType = ageGroupType;
        }

        public string AgeGroupType { get; set; }
        public string CustomGroupName { get; set; }
        public List<CompetitorOnEvent> Competitors { get; set; }

        public void AdCompetitors(Competitor competitor) =>
            Competitors.Add(new CompetitorOnEvent(competitor));
    }
}