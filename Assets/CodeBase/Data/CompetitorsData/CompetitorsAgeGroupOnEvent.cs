using System.Collections.Generic;

namespace CodeBase.Data
{
    public class CompetitorsAgeGroupOnEvent
    {
        public CompetitorsAgeGroupOnEvent(AgeGroup ageGroupType, string customGroupName = null)
        {
            Competitors = new List<CompetitorOnEvent>();
            AgeGroupType = ageGroupType;
            if (ageGroupType == AgeGroup.CustomGroup)
                CustomGroupName = customGroupName;
        }

        public AgeGroup AgeGroupType { get; set; }
        public string CustomGroupName { get; set; }
        public List<CompetitorOnEvent> Competitors { get; set; }

        public void AdCompetitors(Competitor competitor) =>
            Competitors.Add(new CompetitorOnEvent(competitor));
    }
}